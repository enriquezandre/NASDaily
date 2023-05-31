using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class OASMappings : Profile
    {
        public OASMappings()
        {
            CreateMap<OAS, OASDto>().ReverseMap();
            CreateMap<OASCreationDto, OAS>();
            CreateMap<OASUpdateDto, OAS>();
        }
    }
}
