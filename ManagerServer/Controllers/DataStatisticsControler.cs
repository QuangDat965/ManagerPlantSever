using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;
using ManagerServer.Service.DataStatisticsService;
using Microsoft.AspNetCore.Mvc;

namespace ManagerServer.Controllers
{
    public class DataStatisticsControler : ControllerBase
    {
        private readonly IDataStatisticsService dataStatisticsService;

        public DataStatisticsControler(IDataStatisticsService dataStatisticsService)
        {
            this.dataStatisticsService = dataStatisticsService;
        }

        public async Task<ResponseModel<StatisticalResponseModel>> GetStaticalDataResponseByHourZone(StatisticalDataZoneQueryModel queryModel)
        {
            return await dataStatisticsService.GetStaticalDataResponseByHourZone (queryModel);
        }
    }
}
