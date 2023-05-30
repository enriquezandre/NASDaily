namespace nas_daily_api.Models
{
    public class Office
    {
        public string? OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public Superior Superior { get; set; } = new Superior();
        public List<NAS> Scholars { get; set; } = new List<NAS>();
    }
}
