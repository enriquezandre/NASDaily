using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Models
{
    public class NAS
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("NASId")]
        public string? NASId { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Program { get; set; }
        public string? Year { get; set; }
        public string? Semester { get; set; }
        public string? SchoolYear { get; set; }
        public Office Office { get; set; } = new Office();
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
        public List<Log> Logs { get; set; } = new List<Log>();
    }
}
