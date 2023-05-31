using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IEvaluationRatingService
    {
        Task<EvaluationRatingDto?> GetEvaluationRatingByEvaluationRatingId(string EvaluationRatingId);
        Task<string> DeleteEvaluationRatingByEvaluationRatingId(string EvaluationRatingId);
        Task<IEnumerable<EvaluationRatingDto>> GetAllEvaluationRating();
        Task<EvaluationRatingDto> CreateEvaluationRating(EvaluationRatingCUDto EvaluationRating);
        Task UpdateEvaluationRating(EvaluationRatingCUDto EvaluationRating, string EvaluationRatingId);
    }
}
