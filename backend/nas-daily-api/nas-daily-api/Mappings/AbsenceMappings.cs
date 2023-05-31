using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class AbsenceMappings : Profile
    {
        public AbsenceMappings() {

            CreateMap<Absence, AbsenceDto>().ReverseMap();
            CreateMap<AbsenceCreationDto, Absence>();
            CreateMap<AbsenceUpdateDto, Absence>();
        }
    }
}
