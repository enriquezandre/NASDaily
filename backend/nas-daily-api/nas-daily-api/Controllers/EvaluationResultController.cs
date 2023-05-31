using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/evaluationResult")]
    [ApiController]
    public class EvaluationResultController : ControllerBase
    {
        private readonly IEvaluationResultService _evaluationResultService;
        private readonly ILogger<EvaluationResultController> _logger;

        public EvaluationResultController(IEvaluationResultService EvaluationResultService, ILogger<EvaluationResultController> logger)
        {
            _evaluationResultService = EvaluationResultService;
            _logger = logger;
        }

        [HttpGet("{EvaluationResultId}")]
        public async Task<IActionResult> GetEvaluationResultByEvaluationResultId(string EvaluationResultId)
        {
            var EvaluationResult = await _evaluationResultService.GetEvaluationResultByEvaluationResultId(EvaluationResultId);
            if (EvaluationResult == null)
                return NotFound();

            return Ok(EvaluationResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluationResult()
        {
            var allEvaluationResult = await _evaluationResultService.GetAllEvaluationResult();
            return Ok(allEvaluationResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluationResult(EvaluationResultCUDto EvaluationResult)
        {
            var createdEvaluationResult = await _evaluationResultService.CreateEvaluationResult(EvaluationResult);
            return CreatedAtAction(nameof(GetEvaluationResultByEvaluationResultId), new { createdEvaluationResult.EvaluationResultId }, createdEvaluationResult);
        }

        [HttpPut("{EvaluationResultId}")]
        public async Task<IActionResult> UpdateEvaluationResult(EvaluationResultCUDto EvaluationResult, string EvaluationResultId)
        {
            await _evaluationResultService.UpdateEvaluationResult(EvaluationResult, EvaluationResultId);
            return NoContent();
        }

        [HttpDelete("{EvaluationResultId}")]
        public async Task<IActionResult> DeleteEvaluationResultByEvaluationResultId(string EvaluationResultId)
        {
            await _evaluationResultService.DeleteEvaluationResultByEvaluationResultId(EvaluationResultId);
            return NoContent();
        }
    }
}
