using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IEvaluationResultService
    {
        EvaluationResultDto GetEvaluationResultByEvaluationResultId(string evaluationResultId);
        string DeleteEvaluationResultByEvaluationResultId(string evaluationResultId);
        List<EvaluationResultDto> GetAllEvaluationResult();
        EvaluationResultDto CreateEvaluationResult(EvaluationResultDto evaluationResult);
        void UpdateEvaluationResult(EvaluationResultDto evaluationResult, string evaluationResultId);
    }
}
