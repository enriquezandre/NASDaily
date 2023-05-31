using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Models
{
    public class Tasks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? TaskId { get; set; }
        public string? ActivitiesDone { get; set;}
        public string? SkillsLearned { get; set; }
        public string? ValuesLearned { get; set; }
    }
}
