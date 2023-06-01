using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Dtos
{
    public class EvaluationResultCUDto
    {
        public string? TimeKeepingStatus { get; set; }
        public string? AllowedForEnrollment { get; set; }
        public string? UnitsAllowed { get; set; }
    }
}
