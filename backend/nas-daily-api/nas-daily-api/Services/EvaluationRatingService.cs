using nas_daily_api.Dtos;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class EvaluationRatingService : IEvaluationRatingService
    {
        private readonly IEvaluationRatingRepository _evaluationRatingRepository;

        public EvaluationRatingService(IEvaluationRatingRepository EvaluationRatingRepository)
        {
            _evaluationRatingRepository = EvaluationRatingRepository;
        }
        public EvaluationRatingDto CreateEvaluationRating(EvaluationRatingDto EvaluationRating)
        {
            return _evaluationRatingRepository.Create(EvaluationRating);
        }

        public string DeleteEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            return _evaluationRatingRepository.DeleteByEvaluationRatingId(EvaluationRatingId);
        }

        public List<EvaluationRatingDto> GetAllEvaluationRating()
        {
            return _evaluationRatingRepository.GetAllEvaluationRating();
        }

        public EvaluationRatingDto GetEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            return _evaluationRatingRepository.GetByEvaluationRatingId(EvaluationRatingId);
        }

        public void UpdateEvaluationRating(EvaluationRatingDto EvaluationRating, string EvaluationRatingId)
        {
            _evaluationRatingRepository.Update(EvaluationRating, EvaluationRatingId);
        }
    }
}
