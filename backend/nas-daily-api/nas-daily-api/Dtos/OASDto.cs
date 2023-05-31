using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nas_daily_api.Dtos
{
    public class OASDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("OASId")]
        public string? OASId { get; set; }

        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}