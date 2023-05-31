using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nas_daily_api.Dtos
{
    public class AbsenceDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("AbsenceId")]
        public string? AbsenceId { get; set; }
        public string? Excused { get; set; }
        public string? Unexcused { get; set; }
        public string? Ftp { get; set; }
        public string? LateOver10mins { get; set; }
        public string? LateOver45mins { get; set; }
    }
}
