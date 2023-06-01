using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class EvaluationRatingMappings : Profile
    {
        public EvaluationRatingMappings() 
        {
            CreateMap<EvaluationRating, EvaluationRatingDto>().ReverseMap();
            CreateMap<EvaluationRatingCUDto, EvaluationRating>();
        }

    }
}
