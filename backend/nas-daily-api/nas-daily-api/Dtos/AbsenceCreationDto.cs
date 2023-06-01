using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nas_daily_api.Dtos
{
    public class AbsenceCreationDto
    {
        public int? Excused { get; set; }
        public int? Unexcused { get; set; }
        public string? Ftp { get; set; }
        public string? LateOver10mins { get; set; }
        public string? LateOver45mins { get; set; }
    }
}
