using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using nas_daily_api.Models;

namespace nas_daily_api.Dtos
{
    public class SuperiorDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("SuperiorId")]
        public string? SuperiorId { get; set; }
        public string? SuperiorName { get; set; }
    }
}
