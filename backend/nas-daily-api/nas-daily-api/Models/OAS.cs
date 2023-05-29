namespace nas_daily_api.Models
{
    public class OAS
    {
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public List<Office> Offices { get; set; } = new List<Office>();
        public List<NAS> Scholars { get; set; } = new List<NAS>();
    }
}
