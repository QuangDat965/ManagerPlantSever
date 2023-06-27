using ManagerServer.Database.MongoEntity;
using ManagerServer.Service.DataStatisticsMongoDBService;
using Microsoft.AspNetCore.Mvc;

namespace ManagerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoAsyncDataController : ControllerBase
    {
        private readonly IDataStatisticsMongoDBService dataStatisticsMongoDBService;
        public MongoAsyncDataController(IDataStatisticsMongoDBService dataStatisticsMongoDBService)
        {
            this.dataStatisticsMongoDBService = dataStatisticsMongoDBService;
        }
        [HttpGet]
        public async Task<List<TemperatureHumidityDeviceEntity>> PullDataMongoToDatabaseRelationship()
        {
            return await dataStatisticsMongoDBService.PullDataMongoToDatabaseRelationship();
        }
    }
}
