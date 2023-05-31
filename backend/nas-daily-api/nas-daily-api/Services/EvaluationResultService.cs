using nas_daily_api.Dtos;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class EvaluationResultService : IEvaluationResultService
    {
        private readonly IEvaluationResultRepository _evaluationResultRepository;

        public EvaluationResultService(IEvaluationResultRepository evaluationResultRepository)
        {
            _evaluationResultRepository = evaluationResultRepository;
        }
        public EvaluationResultDto CreateEvaluationResult(EvaluationResultDto evaluationResult)
        {
            return _evaluationResultRepository.Create(evaluationResult);
        }

        public string DeleteEvaluationResultByEvaluationResultId(string evaluationResultId)
        {
            return _evaluationResultRepository.DeleteByEvaluationId(evaluationResultId);
        }

        public List<EvaluationResultDto> GetAllEvaluationResult()
        {
            return _evaluationResultRepository.GetAllEvaluationResult();
        }

        public EvaluationResultDto GetEvaluationResultByEvaluationResultId(string evaluationResultId)
        {
            return _evaluationResultRepository.GetByEvaluationResultId(evaluationResultId);
        }

        public void UpdateEvaluationResult(EvaluationResultDto evaluationResult, string evaluationResultId)
        {
            _evaluationResultRepository.Update(evaluationResult, evaluationResultId);
        }
    }
}
