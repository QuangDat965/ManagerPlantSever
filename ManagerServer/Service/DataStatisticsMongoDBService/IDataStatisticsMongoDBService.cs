using ManagerServer.Database.MongoEntity;

namespace ManagerServer.Service.DataStatisticsMongoDBService
{
    public interface IDataStatisticsMongoDBService
    {
        Task PushDataTemperatureHumidityToDB(TemperatureHumidityDeviceEntity temperatureHumidityDeviceEntity);
        Task PushDataTemperatureHumidityToDB(RainDetectionEntity rainDetectionEntity);
        Task<List<TemperatureHumidityDeviceEntity>> PullDataMongoToDatabaseRelationship();
    }
}
