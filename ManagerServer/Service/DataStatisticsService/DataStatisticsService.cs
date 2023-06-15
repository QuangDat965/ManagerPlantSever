using ManagerServer.Common.Mapper;
using ManagerServer.Database;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;
using Microsoft.EntityFrameworkCore;

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
        private async Task<(List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>, List<StatisticalDataResponseModel>)> GetStaticalDataResponseByHourInZone(StatisticalDataZoneQueryModel queryModel)
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
                return (result1, result2, result3);
            }
            catch ( Exception ex )
            {
                throw new Exception (ex.Message);
            }
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
                    //var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);
                    //data = new StatisticalResponseModel ()
                    //{
                    //    Temperatures = result1,
                    //    Rain = result2,
                    //    Humidities = result3,

                    //};
                }
                else if ( queryModel.Period == Common.Enum.StatisticalPeriod.Week )
                {
                    //var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);
                    //data = new StatisticalResponseModel ()
                    //{
                    //    Temperatures = result1,
                    //    Rain = result2,
                    //    Humidities = result3,

                    //};
                }
                else if ( queryModel.Period == Common.Enum.StatisticalPeriod.Month )
                {
                    //var (result1, result2, result3) = await GetStaticalDataResponseByHourInZone (queryModel);
                    //data = new StatisticalResponseModel ()
                    //{
                    //    Temperatures = result1,
                    //    Rain = result2,
                    //    Humidities = result3,

                    //};
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
    }
}
