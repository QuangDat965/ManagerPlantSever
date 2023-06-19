namespace ManagerServer.Database.MongoEntity
{
    public class TemperatureHumidityDeviceEntity
    {
        public string? Id { get; set; }
        public DateTime ValueDate { get; set; } = DateTime.Now;
        public string TemperatureValue { get; set; } = string.Empty;
        public string HumidityValue { get; set; } = string.Empty;
    }
}
