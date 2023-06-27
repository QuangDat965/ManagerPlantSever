using ManagerServer.Database.MongoEntity;
using ManagerServer.Model.MongoModel;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ManagerServer.Service.DataStatisticsMongoDBService
{
    public class DataStatisticsMongoDBService : IDataStatisticsMongoDBService
    {
        private readonly IMongoCollection<TemperatureHumidityDeviceEntity> TemperatureHumidityCollection;

        public DataStatisticsMongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            TemperatureHumidityCollection = database.GetCollection<TemperatureHumidityDeviceEntity>(mongoDBSettings.Value.TemperatureHuminityDevice);
        }

        public async Task<List<TemperatureHumidityDeviceEntity>> PullDataMongoToDatabaseRelationship()
        {
            var dataTemperatureHumidity = await TemperatureHumidityCollection.Find<TemperatureHumidityDeviceEntity>(new BsonDocument()).ToListAsync();
            return dataTemperatureHumidity;
        }

        public Task PushDataToDB(TemperatureHumidityDeviceEntity temperatureHumidityDeviceEntity, RainDetectionEntity rainDetectionEntity)
        {
            throw new NotImplementedException();
        }
    }
}
