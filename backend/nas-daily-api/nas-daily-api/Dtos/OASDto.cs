using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nas_daily_api.Dtos
{
    public class OASDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OASId { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}