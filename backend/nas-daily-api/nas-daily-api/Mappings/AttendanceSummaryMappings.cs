using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class AttendanceSummaryMappings : Profile
    {
        public AttendanceSummaryMappings()
        {
            CreateMap<AttendanceSummary, AttendanceSummaryDto>().ReverseMap();
            CreateMap<AttendanceSummaryCUDto, AttendanceSummary>();
        }
    }
}
