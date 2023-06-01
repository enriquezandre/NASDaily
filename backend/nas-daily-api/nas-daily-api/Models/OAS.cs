using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Models
{
    public class OAS
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OASId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public List<Office> Offices { get; set; } = new List<Office>();
        public List<NAS> Scholars { get; set; } = new List<NAS>();
    }
}
