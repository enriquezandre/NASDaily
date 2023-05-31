using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Dtos
{
    public class NASCreationDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? NASId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Program { get; set; }
        public string? Year { get; set; }
        public string? Semester { get; set; }
        public string? SchoolYear { get; set; }
        public string? Office { get; set; }
    }
}
