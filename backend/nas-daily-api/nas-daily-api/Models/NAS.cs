namespace nas_daily_api.Models
{
    public class NAS
    {
        public string? NASId { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Program { get; set; }
        public string? Year { get; set; }
        public string? Semester { get; set; }
        public string? SchoolYear { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public List<Log> log { get; set; } = new List<Log>();
        public Office Office { get; set; } = new Office();
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
        public List<Absence>? Absences { get; set; } = new List<Absence>();
        public List<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();
        public List<EvaluationResult> EvaluationResults { get; set; } = new List<EvaluationResult>();
    }
}
