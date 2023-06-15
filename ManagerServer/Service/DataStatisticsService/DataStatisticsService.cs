using ManagerServer.Database;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Service.DataStatisticsService
{
    public class DataStatisticsService : IDataStatisticsService
    {
        private readonly ManagerDbContext dbContext;

        public DataStatisticsService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ResponseModel<StatisticalDataResponseModel>> GetStaticDataResponseFarm(StatisticalDataZoneQueryModel queryModel)
        {
            throw new NotImplementedException ();
        }



        public Task<ResponseModel<StatisticalDataResponseModel>> GetStaticDataResponseZone(StatisticalDataZoneQueryModel queryModel)
        {
            throw new NotImplementedException ();
        }
    }
}
