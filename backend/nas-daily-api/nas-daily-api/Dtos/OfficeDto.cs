using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using nas_daily_api.Models;

namespace nas_daily_api.Dtos
{
    public class OfficeDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("OfficeId")]
        public string? OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public Superior Superior { get; set; } = new Superior();
        public List<NAS> Scholars { get; set; } = new List<NAS>();
    }
}