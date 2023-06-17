using ManagerServer.Common.Mapper;
using ManagerServer.Database;
using ManagerServer.Database.Entity;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;

namespace ManagerServer.Service.DataStatisticsService
{
    public class DataStatisticsService : IDataStatisticsService
    {
        private readonly ManagerDbContext dbContext;

        public DataStatisticsService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        // IN table , value default Device type = 1 istemperature measurement device
        // IN table , value default Device type = 2 humidity measuring device
        // IN table , value default Device type = 2 RainDetection measuring device

        // thong ke theo gio
        private async Task<Tuple<List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>>> GetStaticalDataResponseByHourInZone(StatisticalDataZoneQueryModel queryModel)
        {
            try
            {
                var DeviceIds = await dbContext.FarmEntities
                                            .Where (f => f.Id == queryModel.FarmId)
                                            .Join (dbContext.ZoneEntities, f => f.Id, z => z.Id, (f, z) => z)
                                            .Where (z => z.Id == queryModel.ZoneId)
                                            .Join (dbContext.MeasuringDeviceEntities, z => z.Id, m => m.Id, (b, c) => c.Id)
                                            .ToListAsync ();



                List<StatisticalDataResponseModel> result1 = new List<StatisticalDataResponseModel> () { };
                List<StatisticalDataResponseModel> result2 = new List<StatisticalDataResponseModel> () { };
                List<StatisticalDataResponseModel> result3 = new List<StatisticalDataResponseModel> () { };
                var statisticalDataResponses = await dbContext.StatisticalDataResponseForHourEntities
                                        .Where (data => DeviceIds.Contains ((int)data.DeviceMeasureId))
                                        .ToListAsync ();
                result1 = statisticalDataResponses
                    .Where (data => data.DeviceType == Common.Enum.DeviceType.HumidityMeasuringDevice)
                    .Select (data => data.StatisticalDataResponseMapping ())
                    .ToList ();
                result2 = statisticalDataResponses
                    .Where (data => data.DeviceType == Common.Enum.DeviceType.RainDetection)
                    .Select (data => data.StatisticalDataResponseMapping ())
                    .ToList ();

                result3 = statisticalDataResponses
                    .Where (data => data.DeviceType == Common.Enum.DeviceType.TemperatureMeasurementDevice)
                    .Select (data => data.StatisticalDataResponseMapping ())
                    .ToList ();
                return Tuple.Create (result1, result2, result3);

            }
            catch
            {
                throw;
            }
        }

        // thong ke theo ngay

        private async Task<Tuple<List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>>> GetStaticalDataResponseByDaysInZone(StatisticalDataZoneQueryModel queryModel)
        {
            var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);

            var data1 = GroupAndTransformData (result1);
            var data2 = GroupAndTransformData (result2);
            var data3 = GroupAndTransformData (result3);

            return Tuple.Create (data1, data2, data3);
        }

        private List<StatisticalDataResponseModel> GroupAndTransformData(List<StatisticalDataResponseModel> data)
        {
            return data.GroupBy (d => d.ValueDate.Date)
                .Select (d => new StatisticalDataResponseModel
                {
                    // DateRetrive = DateTime.Now,
                    ValueDate = d.Key,
                    AvgValue = d.Average (d => d.AvgValue),
                    TotalValue = d.Sum (d => d.TotalValue),
                    MaxValue = d.Max (d => d.MaxValue),
                    MinValue = d.Min (d => d.MinValue),
                })
                .ToList ();
        }

        // thong ke theo thang
        private async Task<Tuple<List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>>> GetStaticalDataResponseByMonthInZone(StatisticalDataZoneQueryModel queryModel)
        {
            var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);

            var data1 = GroupAndTransformData (result1, d => d.ValueDate.Date.Month);
            var data2 = GroupAndTransformData (result2, d => d.ValueDate.Date.Month);
            var data3 = GroupAndTransformData (result3, d => d.ValueDate.Date.Month);

            return Tuple.Create (data1, data2, data3);
        }

        private List<StatisticalDataResponseModel> GroupAndTransformData(List<StatisticalDataResponseModel> data, Func<StatisticalDataResponseModel, int> groupKeySelector)
        {
            return data.GroupBy (groupKeySelector)
                .Select (d => new StatisticalDataResponseModel
                {
                    // DateRetrive = DateTime.Now,
                    ValueDate = d.Select (d => d.ValueDate).FirstOrDefault (),
                    AvgValue = d.Average (d => d.AvgValue),
                    TotalValue = d.Sum (d => d.TotalValue),
                    MaxValue = d.Max (d => d.MaxValue),
                    MinValue = d.Min (d => d.MinValue),
                })
                .ToList ();
        }

        // thống kê theo tuần (weekly statistics)
        // Dùng để lấy ra ngày bắt đầu của tuần
        private DateTime GetWeekStartDate(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays (-1 * diff).Date;
        }
        private async Task<Tuple<List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>>> GetStaticalDataResponseByWeekInZone(StatisticalDataZoneQueryModel queryModel)
        {
            var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);

            var TemperaturesweeklyData = GroupAndTransformData (result1, d => GetWeekStartDate (d.ValueDate));
            var RainweeklyData = GroupAndTransformData (result2, d => GetWeekStartDate (d.ValueDate));
            var HumiditiessweeklyData = GroupAndTransformData (result3, d => GetWeekStartDate (d.ValueDate));

            return Tuple.Create (TemperaturesweeklyData, RainweeklyData, HumiditiessweeklyData);
        }

        private List<StatisticalDataResponseModel> GroupAndTransformData(List<StatisticalDataResponseModel> data, Func<StatisticalDataResponseModel, DateTime> groupKeySelector)
        {
            return data.GroupBy (groupKeySelector)
                .Select (g => new StatisticalDataResponseModel
                {
                    ValueDate = g.Key,
                    TotalValue = g.Sum (d => d.TotalValue),
                    AvgValue = g.Average (d => d.AvgValue),
                    MinValue = g.Aggregate (double.MaxValue, (min, d) => Math.Min (min, d.AvgValue)),
                    MaxValue = g.Aggregate (double.MinValue, (max, d) => Math.Max (max, d.AvgValue)),
                    DateRetrive = DateTime.Now,
                })
                .ToList ();
        }




        public async Task<ResponseModel<StatisticalResponseModel>> GetStaticalDataResponseByHourZone(StatisticalDataZoneQueryModel queryModel)
        {
            try
            {
                StatisticalResponseModel data = new StatisticalResponseModel () { };
                if ( queryModel.Period == Common.Enum.StatisticalPeriod.Hour )
                {
                    var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);
                    data = new StatisticalResponseModel ()
                    {
                        Temperatures = result1,
                        Rain = result2,
                        Humidities = result3,

                    };
                }
                else if ( queryModel.Period == Common.Enum.StatisticalPeriod.Day )
                {
                    var (result1, result2, result3) = await GetStaticalDataResponseByDaysInZone (queryModel);
                    data = new StatisticalResponseModel ()
                    {
                        Temperatures = result1,
                        Rain = result2,
                        Humidities = result3,
                    };
                }
                else if ( queryModel.Period == Common.Enum.StatisticalPeriod.Week )
                {
                    var (result1, result2, result3) = await GetStaticalDataResponseByWeekInZone (queryModel);
                    data = new StatisticalResponseModel ()
                    {
                        Temperatures = result1,
                        Rain = result2,
                        Humidities = result3,

                    };
                }
                else if ( queryModel.Period == Common.Enum.StatisticalPeriod.Month )
                {
                    var (result1, result2, result3) = await GetStaticalDataResponseByMonthInZone (queryModel);
                    data = new StatisticalResponseModel ()
                    {
                        Temperatures = result1,
                        Rain = result2,
                        Humidities = result3,

                    };
                }
                return new ResponseModel<StatisticalResponseModel> ()
                {
                    code = 1,
                    message = "Success",
                    data = data
                };
            }
            catch ( Exception ex )
            {
                throw new Exception (ex.Message);
            }
        }

        public Task<ResponseModel<IEnumerable<StatisticalDataResponseModel>>> GetStaticalDataResponseFarm(StatisticalDataZoneQueryModel queryModel)
        {
            throw new NotImplementedException ();
        }
        public async Task<List<MeasuringDeviceEntity>> GetStaticalDataResponseAll(StatisticalDataZoneQueryModel queryModel)
        {
            return await dbContext.MeasuringDeviceEntities.Where (q => q.ZoneId == queryModel.ZoneId)
                        .Include (c => c.StatisticalDataResponsesForHours)
                        .ToListAsync ();
        }

    }
}
