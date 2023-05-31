namespace nas_daily_api.Models
{
    public class Absence
    {
        public string? AbsenceId { get; set; }
        public string? Excused { get; set; }
        public string? Unexcused { get; set; }
        public string? Ftp { get; set; }
        public string? LateOver10mins { get; set; }
        public string? LateOver45mins { get; set; }
    }
}
