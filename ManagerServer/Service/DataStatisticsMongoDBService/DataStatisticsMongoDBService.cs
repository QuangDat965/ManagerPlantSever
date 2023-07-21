using ManagerServer.Database.MongoEntity;
using ManagerServer.Model.MongoModel;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ManagerServer.Service.DataStatisticsMongoDBService
{
    public class DataStatisticsMongoDBService : IDataStatisticsMongoDBService
    {
        private readonly IMongoCollection<DataMongoDeviceEntity> datamongodeviceentity;
        private readonly MongoClient client;
        public DataStatisticsMongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            this.client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var database = this.client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            datamongodeviceentity = database.GetCollection<DataMongoDeviceEntity>(mongoDBSettings.Value.DataDevice);
        }

        //public Task Connection()
        //{
        //    client.Cluster.
        //}

        public async Task<List<DataMongoDeviceEntity>> PullDataMongoToDatabaseRelationship()
        {
            var dataTemperatureHumidity = await datamongodeviceentity.Find<DataMongoDeviceEntity>(new BsonDocument()).ToListAsync();
            return dataTemperatureHumidity;
        }

        public async Task PushDataToDB(DataMongoDeviceEntity addModel)
        {
            addModel.Id = ObjectId.GenerateNewId().ToString();
            await datamongodeviceentity.InsertOneAsync(addModel);
            Task.CompletedTask.Wait();
        }

        //public Task PushDataTemperatureHumidityToDB(RainDetectionEntity rainDetectionEntity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}