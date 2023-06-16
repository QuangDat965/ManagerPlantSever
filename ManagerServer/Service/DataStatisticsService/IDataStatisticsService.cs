using ManagerServer.Database.Entity;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Service.DataStatisticsService
{
    public interface IDataStatisticsService
    {
        public Task<List<MeasuringDeviceEntity>> GetStaticalDataResponseAll(StatisticalDataZoneQueryModel queryModel);
        // Lấy giá trị thống kê  của 1 Zone
        public Task<ResponseModel<StatisticalResponseModel>> GetStaticalDataResponseByHourZone(StatisticalDataZoneQueryModel queryModel);

        // Lấy giá trị thống kê  của 1 Farm
        public Task<ResponseModel<IEnumerable<StatisticalDataResponseModel>>> GetStaticalDataResponseFarm(StatisticalDataZoneQueryModel queryModel);
    }
}
