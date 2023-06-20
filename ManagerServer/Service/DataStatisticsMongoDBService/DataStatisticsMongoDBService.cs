using ManagerServer.Database.MongoEntity;

namespace ManagerServer.Service.DataStatisticsMongoDBService
{
    public class DataStatisticsMongoDBService : IDataStatisticsMongoDBService
    {
        public Task PullDataMongoToDatabaseRelationship(TemperatureHumidityDeviceEntity temperatureHumidityDeviceEntity, RainDetectionEntity rainDetectionEntity)
        {
            throw new NotImplementedException ();
        }

        public Task PushDataToDB(TemperatureHumidityDeviceEntity temperatureHumidityDeviceEntity, RainDetectionEntity rainDetectionEntity)
        {
            throw new NotImplementedException ();
        }
    }
}
