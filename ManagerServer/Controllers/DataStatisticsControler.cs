using ManagerServer.Database.Entity;
using ManagerServer.Model.ResponeModel;
using ManagerServer.Model.StatisticalDataResponse;
using ManagerServer.Service.DataStatisticsService;
using Microsoft.AspNetCore.Mvc;

namespace ManagerServer.Controllers
{
    [ApiController, Route ("api/[controller]")]
    public class DataStatisticsControler : ControllerBase
    {
        private readonly IDataStatisticsService dataStatisticsService;

        public DataStatisticsControler(IDataStatisticsService dataStatisticsService)
        {
            this.dataStatisticsService = dataStatisticsService;
        }
        [HttpPost ("GetStaticalDataResponseByHourZone")]
        public async Task<ResponseModel<StatisticalResponseModel>> GetStaticalDataResponseByHourZone([FromBody] StatisticalDataZoneQueryModel queryModel)
        {
            return await dataStatisticsService.GetStaticalDataResponseByHourZone (queryModel);
        }
        [HttpPost ("getall")]
        public async Task<List<MeasuringDeviceEntity>> GetStaticalDataResponseAll(StatisticalDataZoneQueryModel queryModel)
        {
            return await dataStatisticsService.GetStaticalDataResponseAll (queryModel);
        }

    }
}
