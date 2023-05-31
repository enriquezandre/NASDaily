using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using nas_daily_api.Models;

namespace nas_daily_api.Dtos
{
    public class EvaluationResultDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("EvaluationResultId")]
        public string? EvaluationResultId { get; set; }
        public string? TimeKeepingStatus { get; set; }
        public string? AllowedForEnrollment { get; set; }
        public string? UnitsAllowed { get; set; }
        public NAS Nas { get; set; } = new NAS();
    }
}
