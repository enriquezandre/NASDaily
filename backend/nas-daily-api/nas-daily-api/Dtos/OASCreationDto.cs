using MongoDB.Bson.Serialization.Attributes;

namespace nas_daily_api.Dtos
{
    public class OASCreationDto
    {
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
