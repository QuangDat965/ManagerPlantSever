using ManagerServer.Database.MongoEntity;

namespace ManagerServer.Service.DataStatisticsMongoDBService
{
    public interface IDataStatisticsMongoDBService
    {
        Task PushDataToDB(TemperatureHumidityDeviceEntity temperatureHumidityDeviceEntity, RainDetectionEntity rainDetectionEntity);
        Task<List<TemperatureHumidityDeviceEntity>> PullDataMongoToDatabaseRelationship();
    }
}
