using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class NASMappings : Profile
    {
        public NASMappings()
        {
            CreateMap<NAS, NASDto>()
                .ForMember(dest => dest.Office, opt => opt.MapFrom(src => new OfficeDto
                {
                    OfficeId = src.Office.OfficeId,
                    OfficeName = src.Office.OfficeName
                }))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ForMember(dest => dest.Logs, opt => opt.MapFrom(src => src.Logs));

            CreateMap<Tasks, TasksDto>();
            CreateMap<Log, LogDto>();

            CreateMap<NASDto, NAS>();
            CreateMap<NASOfficeDto, OfficeDto>();
        }
    }
}