using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ManagerServer.Database.MongoEntity
{
    public class DataMongoDeviceEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("ValueDate")]
        [JsonPropertyName("ValueDate")]
        public DateTime ValueDate { get; set; } = DateTime.Now;
        [BsonElement("Topic")]
        [JsonPropertyName("Topic")]
        public string? Topic { get; set; }
        [BsonElement("PayLoad")]
        [JsonPropertyName("PayLoad")]
        public string? PayLoad { get; set; }

    }
}
