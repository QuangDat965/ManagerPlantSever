using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Service.DataStatisticsService
{
    public interface IDataStatisticsService
    {
        // Lấy giá trị thống kê  của 1 Zone
        public Task<ResponseModel<StatisticalDataResponseModel>> GetStaticDataResponseZone(StatisticalDataZoneQueryModel queryModel);

        // Lấy giá trị thống kê  của 1 Farm
        public Task<ResponseModel<StatisticalDataResponseModel>> GetStaticDataResponseFarm(StatisticalDataZoneQueryModel queryModel);
    }
}
