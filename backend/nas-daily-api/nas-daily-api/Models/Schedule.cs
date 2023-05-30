namespace nas_daily_api.Models
{
    public class Schedule
    {
        public string? ScheduleId { get; set; }
        public List<DateTime>? StartTimes { get; set; }
        public List<DateTime>? EndTimes { get; set; }
        public bool? BrokenSched { get; set; }
        public int NumOfSched { get; set; }
    }
}
