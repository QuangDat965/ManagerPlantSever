using ManagerServer.Database.Entity;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Service.DataStatisticsService
{
    public interface IDataStatisticsService
    {
        // Lấy giá trị thống kê  của 1 Zone
        public Task<ResponseModel<StatisticalDataResponseForHourEntity>> GetStaticDataResponseZone(StatisticalDataZoneQueryModel queryModel);

        // Lấy giá trị thống kê  của 1 Farm
        public Task<ResponseModel<StatisticalDataResponseForHourEntity>> GetStaticDataResponseFarm(StatisticalDataZoneQueryModel queryModel);
    }
}
