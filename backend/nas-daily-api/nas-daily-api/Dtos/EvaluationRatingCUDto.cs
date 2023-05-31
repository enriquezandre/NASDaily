using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Dtos
{
    public class EvaluationRatingCUDto
    {
        public string? AttendanceAndPunctuality { get; set; }
        public string? QualOfWorkOutput { get; set; }
        public string? QualOfWorkInput { get; set; }
        public string? AttitudeAndWorkBehaviour { get; set; }
        public string? OverallAssessment { get; set; }
        public string? OverallRating { get; set; }
    }
}
