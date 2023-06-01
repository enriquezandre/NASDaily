using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public interface IEvaluationRatingRepository
    {
        Task<EvaluationRating> GetByEvaluationRatingId(string EvaluationRatingId);

        Task<string> DeleteByEvaluationRatingId(string EvaluationRatingId);

        Task<EvaluationRating> Create(EvaluationRating EvaluationRating);
        Task<EvaluationRating> Update(EvaluationRating EvaluationRating, string evaluationRatingId);
        Task<IEnumerable<EvaluationRating>> GetAllEvaluationRating();
    }
}
