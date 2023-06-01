using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class EvaluationRatingService : IEvaluationRatingService
    {
        private readonly IEvaluationRatingRepository _evaluationRatingRepository;
        private readonly IMapper _mapper;

        public EvaluationRatingService(IEvaluationRatingRepository EvaluationRatingRepository, IMapper mapper)
        {
            _evaluationRatingRepository = EvaluationRatingRepository;
            _mapper = mapper;
        }
        public async Task<EvaluationRatingDto> CreateEvaluationRating(EvaluationRatingCUDto EvaluationRating)
        {
            var EvaluationRatingModel = _mapper.Map<EvaluationRating>(EvaluationRating);
            await _evaluationRatingRepository.Create(EvaluationRatingModel);

            return _mapper.Map<EvaluationRatingDto>(EvaluationRatingModel);
        }

        public async Task<string> DeleteEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            return await _evaluationRatingRepository.DeleteByEvaluationRatingId(EvaluationRatingId);
        }

        public async Task<EvaluationRatingDto?> GetEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            var EvaluationRatingModel = await _evaluationRatingRepository.GetByEvaluationRatingId(EvaluationRatingId);
            if (EvaluationRatingModel == null) return null;

            return _mapper.Map<EvaluationRatingDto>(EvaluationRatingModel);
        }

        public async Task<IEnumerable<EvaluationRatingDto>> GetAllEvaluationRating()
        {
            var EvaluationRatingList = await _evaluationRatingRepository.GetAllEvaluationRating();
            return _mapper.Map<IEnumerable<EvaluationRatingDto>>(EvaluationRatingList);
        }

        public async Task UpdateEvaluationRating(EvaluationRatingCUDto EvaluationRating, string EvaluationRatingId)
        {
            var EvaluationRatingModel = _mapper.Map<EvaluationRating>(EvaluationRating);
            await _evaluationRatingRepository.Update(EvaluationRatingModel, EvaluationRatingId);
        }
    }
}
