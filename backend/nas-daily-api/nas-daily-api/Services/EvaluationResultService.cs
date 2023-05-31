using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class EvaluationResultService : IEvaluationResultService
    {
        private readonly IEvaluationResultRepository _evaluationResultRepository;
        private readonly IMapper _mapper;

        public EvaluationResultService(IEvaluationResultRepository EvaluationResultRepository, IMapper mapper)
        {
            _evaluationResultRepository = EvaluationResultRepository;
            _mapper = mapper;
        }
        public async Task<EvaluationResultDto> CreateEvaluationResult(EvaluationResultCUDto EvaluationResult)
        {
            var EvaluationResultModel = _mapper.Map<EvaluationResult>(EvaluationResult);
            await _evaluationResultRepository.Create(EvaluationResultModel);

            return _mapper.Map<EvaluationResultDto>(EvaluationResultModel);
        }

        public async Task<string> DeleteEvaluationResultByEvaluationResultId(string EvaluationResultId)
        {
            return await _evaluationResultRepository.DeleteByEvaluationId(EvaluationResultId);
        }

        public async Task<EvaluationResultDto?> GetEvaluationResultByEvaluationResultId(string evaluationResultId)
        {
            var EvaluationResultModel = await _evaluationResultRepository.GetByEvaluationResultId(evaluationResultId);
            if (EvaluationResultModel == null) return null;

            return _mapper.Map<EvaluationResultDto>(EvaluationResultModel);
        }

        public async Task<IEnumerable<EvaluationResultDto>> GetAllEvaluationResult()
        {
            var EvaluationResultList = await _evaluationResultRepository.GetAllEvaluationResult();
            return _mapper.Map<IEnumerable<EvaluationResultDto>>(EvaluationResultList);
        }

        public async Task UpdateEvaluationResult(EvaluationResultCUDto EvaluationResult, string EvaluationResultId)
        {
            var EvaluationResultModel = _mapper.Map<EvaluationResult>(EvaluationResult);
            await _evaluationResultRepository.Update(EvaluationResultModel, EvaluationResultId);
        }
    }
}
