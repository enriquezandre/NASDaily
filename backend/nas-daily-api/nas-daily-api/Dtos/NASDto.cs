using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using nas_daily_api.Models;

namespace nas_daily_api.Dtos
{
    public class NASDto
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
        public List<LogDto> Logs { get; set; } = new List<LogDto>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public List<Absence>? Absences { get; set; } = new List<Absence>();
        public List<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();
        public List<EvaluationResult> EvaluationResults { get; set; } = new List<EvaluationResult>();
    }
}