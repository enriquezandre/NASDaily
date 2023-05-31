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

        public EvaluationResultController(IEvaluationResultService evaluationResultService)
        {
            _evaluationResultService = evaluationResultService;
        }

        [HttpGet("{evaluationResultId}")]
        public IActionResult GetEvaluationResultByEvaluationResultId(string evaluationResultId)
        {
            var evaluationResult = _evaluationResultService.GetEvaluationResultByEvaluationResultId(evaluationResultId);
            if (evaluationResult == null)
                return NotFound();

            return Ok(evaluationResult);
        }

        [HttpGet]
        public IActionResult GetAllevaluationResult()
        {
            var allevaluationResult = _evaluationResultService.GetAllEvaluationResult();
            return Ok(allevaluationResult);
        }

        [HttpPost]
        public IActionResult CreateevaluationResult(EvaluationResultDto evaluationResult)
        {
            var createdevaluationResult = _evaluationResultService.CreateEvaluationResult(evaluationResult);
            return CreatedAtAction(nameof(GetEvaluationResultByEvaluationResultId), new { EvaluationResultId = createdevaluationResult.EvaluationResultId }, createdevaluationResult);
        }

        [HttpPut("{evaluationResultId}")]
        public IActionResult UpdateevaluationResult(EvaluationResultDto evaluationResult, string evaluationResultId)
        {
            _evaluationResultService.UpdateEvaluationResult(evaluationResult, evaluationResultId);
            return NoContent();
        }

        [HttpDelete("{evaluationResultId}")]
        public IActionResult DeleteevaluationResult(string evaluationResultId)
        {
            _evaluationResultService.DeleteEvaluationResultByEvaluationResultId(evaluationResultId);
            return NoContent();
        }
    }
}
