namespace nas_daily_api.Models
{
    public class Absence
    {
        public string? AbsenceId { get; set; }
        public int? Excused { get; set; }
        public int? Unexcused { get; set; }
        public string? Ftp { get; set; }
        public string? LateOver10mins { get; set; }
        public string? LateOver45mins { get; set; }
        public NAS? Nas { get; set; } = new NAS();
    }
}
