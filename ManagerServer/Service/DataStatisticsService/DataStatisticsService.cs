using ManagerServer.Database.Entity;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Service.DataStatisticsService
{
    public class DataStatisticsService : IDataStatisticsService
    {
        public Task<ResponseModel<StatisticalDataResponseForHourEntity>> GetStaticDataResponse(StatisticalDataZoneQueryModel queryModel)
        {
            throw new NotImplementedException ();
        }
    }
}
