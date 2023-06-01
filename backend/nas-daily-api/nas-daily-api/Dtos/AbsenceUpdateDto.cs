namespace nas_daily_api.Dtos
{
    public class AbsenceUpdateDto
    {
        public int? Excused { get; set; }
        public int? Unexcused { get; set; }
        public string? Ftp { get; set; }
        public string? LateOver10mins { get; set; }
        public string? LateOver45mins { get; set; }
    }
}
