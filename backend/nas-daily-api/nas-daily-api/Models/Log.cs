using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace nas_daily_api.Models
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("LogId")]
        public string? LogId { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public string? NASId { get; set; }
    }
}