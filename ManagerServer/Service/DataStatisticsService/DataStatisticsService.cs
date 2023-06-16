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
        // thong ke theo gio
        private async Task<Tuple<List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>>> GetStaticalDataResponseByHourInZone(StatisticalDataZoneQueryModel queryModel)
        {
            try
            {
                var DeviceIds = await dbContext.MeasuringDeviceEntities.Where (q => q.ZoneId == queryModel.ZoneId).Select (q => q.Id).ToListAsync ();
                List<StatisticalDataResponseModel> result1 = new List<StatisticalDataResponseModel> () { };
                List<StatisticalDataResponseModel> result2 = new List<StatisticalDataResponseModel> () { };
                List<StatisticalDataResponseModel> result3 = new List<StatisticalDataResponseModel> () { };
                foreach ( var DeviceId in DeviceIds )
                {
                    List<StatisticalDataResponseModel> StatisticalDataResponse = await (from data in dbContext.StatisticalDataResponseForHourEntities
                                                                                        where data.deviceType == Common.Enum.DeviceType.HumidityMeasuringDevice && data.DeviceMeasureId == DeviceId
                                                                                        select data.StatisticalDataResponseMapping ()).ToListAsync ();
                    if ( StatisticalDataResponse != null )
                    {
                        result1 = result1.Concat (StatisticalDataResponse).ToList ();
                    }
                    StatisticalDataResponse = await (from data in dbContext.StatisticalDataResponseForHourEntities
                                                     where data.deviceType == Common.Enum.DeviceType.RainDetection && data.DeviceMeasureId == DeviceId
                                                     select data.StatisticalDataResponseMapping ()).ToListAsync ();
                    if ( StatisticalDataResponse != null )
                    {
                        result2 = result2.Concat (StatisticalDataResponse).ToList ();
                    }
                    StatisticalDataResponse = await (from data in dbContext.StatisticalDataResponseForHourEntities
                                                     where data.deviceType == Common.Enum.DeviceType.TemperatureMeasurementDevice && data.DeviceMeasureId == DeviceId
                                                     select data.StatisticalDataResponseMapping ()).ToListAsync ();
                    if ( StatisticalDataResponse != null )
                    {
                        result2 = result2.Concat (StatisticalDataResponse).ToList ();
                    }


                }
                return Tuple.Create (result1, result2, result3);
            }
            catch ( Exception ex )
            {
                throw new Exception (ex.Message);
            }
        }

        // thong ke theo ngay
        private async Task<(List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>)> GetStaticalDataResponseByDaysInZone(StatisticalDataZoneQueryModel queryModel)
        {
            var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);
            var data1 = result1.GroupBy (d => d.ValueDate.Date)
                        .Select (d => new StatisticalDataResponseModel
                        {
                            //DateRetrive = DateTime.Now,
                            ValueDate = d.Key,
                            AvgValue = d.Average (d => d.AvgValue),
                            TotalValue = d.Sum (d => d.TotalValue),
                            MaxValue = d.Max (d => d.MaxValue),
                            MinValue = d.Min (d => d.MinValue),
                        }).ToList ();
            var data2 = result2.GroupBy (d => d.ValueDate.Date)
                        .Select (d => new StatisticalDataResponseModel
                        {
                            //DateRetrive = DateTime.Now,
                            ValueDate = d.Key,
                            AvgValue = d.Average (d => d.AvgValue),
                            TotalValue = d.Sum (d => d.TotalValue),
                            MaxValue = d.Max (d => d.MaxValue),
                            MinValue = d.Min (d => d.MinValue),
                        }).ToList ();
            var data3 = result3.GroupBy (d => d.ValueDate.Date)
                        .Select (d => new StatisticalDataResponseModel
                        {
                            //DateRetrive = DateTime.Now,
                            ValueDate = d.Key,
                            AvgValue = d.Average (d => d.AvgValue),
                            TotalValue = d.Sum (d => d.TotalValue),
                            MaxValue = d.Max (d => d.MaxValue),
                            MinValue = d.Min (d => d.MinValue),
                        }).ToList ();

            //var data3 = result3.GroupBy (d => d.ValueDate.Year)
            //            .Select (d => new StatisticalDataResponseModel
            //            {
            //                //DateRetrive = DateTime.Now,
            //                ValueDate = d.Select (d => d.ValueDate).FirstOrDefault (),
            //                AvgValue = d.Average (d => d.AvgValue),
            //                TotalValue = d.Sum (d => d.TotalValue),
            //                MaxValue = d.Max (d => d.MaxValue),
            //                MinValue = d.Min (d => d.MinValue),
            //            }).ToList ();
            return (data1, data2, data3);
        }
        // thong ke theo thang
        private async Task<(List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>)> GetStaticalDataResponseByMonthInZone(StatisticalDataZoneQueryModel queryModel)
        {
            var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);
            var data1 = result1.GroupBy (d => d.ValueDate.Date.Month)
                        .Select (d => new StatisticalDataResponseModel
                        {
                            //DateRetrive = DateTime.Now,
                            ValueDate = d.Select (d => d.ValueDate).FirstOrDefault (),
                            AvgValue = d.Average (d => d.AvgValue),
                            TotalValue = d.Sum (d => d.TotalValue),
                            MaxValue = d.Max (d => d.MaxValue),
                            MinValue = d.Min (d => d.MinValue),
                        }).ToList ();
            var data2 = result2.GroupBy (d => d.ValueDate.Date.Month)
                        .Select (d => new StatisticalDataResponseModel
                        {
                            //DateRetrive = DateTime.Now,
                            ValueDate = d.Select (d => d.ValueDate).FirstOrDefault (),
                            AvgValue = d.Average (d => d.AvgValue),
                            TotalValue = d.Sum (d => d.TotalValue),
                            MaxValue = d.Max (d => d.MaxValue),
                            MinValue = d.Min (d => d.MinValue),
                        }).ToList ();

            var data3 = result3.GroupBy (d => d.ValueDate.Date.Month)
                        .Select (d => new StatisticalDataResponseModel
                        {
                            //DateRetrive = DateTime.Now,
                            ValueDate = d.Select (d => d.ValueDate).FirstOrDefault (),
                            AvgValue = d.Average (d => d.AvgValue),
                            TotalValue = d.Sum (d => d.TotalValue),
                            MaxValue = d.Max (d => d.MaxValue),
                            MinValue = d.Min (d => d.MinValue),
                        }).ToList ();

            return (data1, data2, data3);
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
                    //var (result1, result2, result3) = await GetStaticalDataResponseByWeekInZone (queryModel);
                    //data = new StatisticalResponseModel ()
                    //{
                    //    Temperatures = result1,
                    //    Rain = result2,
                    //    Humidities = result3,

                    //};
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
                        .Include (c => c.StatisticalDataResponsesForDays)
                        .Include (c => c.StatisticalDataResponsesForWeek)
                        .Include (c => c.StatisticalDataResponsesForMonth).ToListAsync ();
        }

    }
}
