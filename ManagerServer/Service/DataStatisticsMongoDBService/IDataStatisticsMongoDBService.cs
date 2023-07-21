using ManagerServer.Database.MongoEntity;

namespace ManagerServer.Service.DataStatisticsMongoDBService
{
    public interface IDataStatisticsMongoDBService
    {
        Task PushDataToDB(DataMongoDeviceEntity addModel);
    }
}
