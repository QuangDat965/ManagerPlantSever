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

    }
}