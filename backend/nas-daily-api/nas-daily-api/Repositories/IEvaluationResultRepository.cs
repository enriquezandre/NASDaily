using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IEvaluationResultRepository
    {
        EvaluationResultDto GetByEvaluationResultId(string EvaluationResultId);

        EvaluationResultDto Create(EvaluationResultDto evaluationResult);
        EvaluationResultDto Update(EvaluationResultDto evaluationResult, string evaluationResultId);
        List<EvaluationResultDto> GetAllEvaluationResult();
        string DeleteByEvaluationId(string evaluationResultId);
    }
}
