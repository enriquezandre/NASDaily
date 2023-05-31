using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class NASMappings : Profile
    {
        public NASMappings()
        {
            CreateMap<NAS, NASDto>();
            CreateMap<NASCreationDto, NAS>()
                .ForMember(dest => dest.NASId, opt => opt.Ignore());
            CreateMap<NASOfficeDto, OfficeDto>();
        }
    }
}