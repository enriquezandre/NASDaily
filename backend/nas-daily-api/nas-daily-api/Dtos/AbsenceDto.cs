using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using nas_daily_api.Models;

namespace nas_daily_api.Dtos
{
    public class AbsenceDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("AbsenceId")]
        public string? AbsenceId { get; set; }
        public int? Excused { get; set; }
        public int? Unexcused { get; set; }
        public string? Ftp { get; set; }
        public string? LateOver10mins { get; set; }
        public string? LateOver45mins { get; set; }
    }
}
