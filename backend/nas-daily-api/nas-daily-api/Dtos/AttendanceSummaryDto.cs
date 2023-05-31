using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Dtos
{
    public class AttendanceSummaryDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("AttendanceSummaryId")]
        public string? AttendanceSummaryId { get; set; }
        public string? TimeKeepingStatus { get; set; }
        public string? AllowedForEnrollment { get; set; }
        public string? UnitsAllowed { get; set; }
    }
}
