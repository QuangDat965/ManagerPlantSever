using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ManagerServer.Database.MongoEntity
{
    public class TemperatureHumidityDeviceEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("ValueDate")]
        [JsonPropertyName("ValueDate")]
        public DateTime ValueDate { get; set; } = DateTime.Now;
        public string TemperatureValue { get; set; } = string.Empty;
        public string HumidityValue { get; set; } = string.Empty;
    }
}
