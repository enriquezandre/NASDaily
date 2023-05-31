using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IEvaluationRatingRepository
    {
        EvaluationRatingDto GetByEvaluationRatingId(string EvaluationRatingId);

        string DeleteByEvaluationRatingId(string EvaluationRatingId);

        EvaluationRatingDto Create(EvaluationRatingDto EvaluationRating);
        EvaluationRatingDto Update(EvaluationRatingDto EvaluationRating, string evaluationRatingId);
        List<EvaluationRatingDto> GetAllEvaluationRating();
    }
}
