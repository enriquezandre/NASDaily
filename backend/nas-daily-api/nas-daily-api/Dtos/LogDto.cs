using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace nas_daily_api.Dtos
{
    public class LogDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? LogId { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public string? NASId { get; set; }
    }
}