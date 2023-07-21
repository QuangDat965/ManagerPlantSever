namespace ManagerServer.Model.MongoModel
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string DataDevice { get; set; } = string.Empty;
        public string RainDetectionDevice { get; set; } = string.Empty;
    }
}
