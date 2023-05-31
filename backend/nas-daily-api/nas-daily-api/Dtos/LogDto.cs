using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace nas_daily_api.Dtos
{
    public class LogDto
    {
        public string? Id { get; set; }

        [BsonElement("LogId")]
        public string? LogId { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public string? NASId { get; set; }
    }
}
