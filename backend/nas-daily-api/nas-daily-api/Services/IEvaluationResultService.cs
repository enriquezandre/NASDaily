using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IEvaluationResultService
    {
        Task<EvaluationResultDto?> GetEvaluationResultByEvaluationResultId(string evaluationResultId);
        Task<string> DeleteEvaluationResultByEvaluationResultId(string evaluationResultId);
        Task<IEnumerable<EvaluationResultDto>> GetAllEvaluationResult();
        Task<EvaluationResultDto> CreateEvaluationResult(EvaluationResultCUDto evaluationResult);
        Task UpdateEvaluationResult(EvaluationResultCUDto evaluationResult, string evaluationResultId);
    }
}
