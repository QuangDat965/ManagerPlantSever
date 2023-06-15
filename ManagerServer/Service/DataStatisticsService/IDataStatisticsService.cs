using ManagerServer.Database.Entity;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;

namespace ManagerServer.Service.DataStatisticsService
{
    public interface IDataStatisticsService
    {
        // Lấy giá trị thống kê  của 1 Zone
        public Task<ResponseModel<StatisticalDataResponseForHourEntity>> GetStaticDataResponse(StatisticalDataQueryModel queryModel);

        // Lấy giá trị thống kê  của 1 Farm

    }
}
