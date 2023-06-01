using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public interface IEvaluationResultRepository
    {
        Task<EvaluationResult> GetByEvaluationResultId(string EvaluationResultId);

        Task<EvaluationResult> Create(EvaluationResult evaluationResult);
        Task<EvaluationResult> Update(EvaluationResult evaluationResult, string evaluationResultId);
        Task<IEnumerable<EvaluationResult>> GetAllEvaluationResult();
        Task<string> DeleteByEvaluationId(string evaluationResultId);
    }
}
