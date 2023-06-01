using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class LogMappings:Profile
    {
        public LogMappings()
        {
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            CreateMap<LogUpdateDto, Log>();
        }
    }
}
