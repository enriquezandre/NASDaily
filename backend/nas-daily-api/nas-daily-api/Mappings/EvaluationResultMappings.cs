using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class EvaluationResultMappings : Profile
    {
        public EvaluationResultMappings()
        {
            CreateMap<EvaluationResult, EvaluationResultDto>().ReverseMap();
            CreateMap<EvaluationResultCUDto, EvaluationResult>();
        }
    }
}
