using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nas_daily_api.Dtos
{
    public class TasksDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("TaskId")]
        public string? TaskId { get; set; }

        public string? Description { get; set; }
    }
}