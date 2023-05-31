using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class OfficeMappings :Profile
    {
        public OfficeMappings()
        {
            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeDto, Office>();
        }
    }
}
