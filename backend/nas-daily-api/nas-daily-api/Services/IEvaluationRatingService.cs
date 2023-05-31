using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IEvaluationRatingService
    {
        EvaluationRatingDto GetEvaluationRatingByEvaluationRatingId(string EvaluationRatingId);
        string DeleteEvaluationRatingByEvaluationRatingId(string EvaluationRatingId);
        List<EvaluationRatingDto> GetAllEvaluationRating();
        EvaluationRatingDto CreateEvaluationRating(EvaluationRatingDto EvaluationRating);
        void UpdateEvaluationRating(EvaluationRatingDto EvaluationRating, string EvaluationRatingId);
    }
}
