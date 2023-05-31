using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using nas_daily_api.Models;

namespace nas_daily_api.Dtos
{
    public class EvaluationRatingDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("EvaluationRatingId")]
        public string? EvaluationRatingId { get; set; }
        public string? AttendanceAndPunctuality { get; set; }
        public string? QualOfWorkOutput { get; set; }
        public string? QualOfWorkInput { get; set; }
        public string? AttitudeAndWorkBehaviour { get; set; }
        public string? OverallAssessment { get; set; }
        public string? OverallRating { get; set; }
        public Superior Superior { get; set; } = new Superior();
    }
}
