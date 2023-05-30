using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nas_daily_api.Dtos
{
    public class ScheduleDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("ScheduleId")]
        public string? ScheduleId { get; set; }
        public List<DateTime>? StartTimes { get; set; }
        public List<DateTime>? EndTimes { get; set; }
        public bool? BrokenSched { get; set; }
        public int NumOfSched { get; set; }
    }
}
