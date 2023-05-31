using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/evaluationRating")]
    [ApiController]
    public class EvaluationRatingController : ControllerBase
    {
        private readonly IEvaluationRatingService _evaluationRatingService;
        private readonly ILogger<EvaluationRatingController> _logger;

        public EvaluationRatingController(IEvaluationRatingService EvaluationRatingService, ILogger<EvaluationRatingController> logger)
        {
            _evaluationRatingService = EvaluationRatingService;
            _logger = logger;
        }

        [HttpGet("{EvaluationRatingId}")]
        public async Task<IActionResult> GetEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            var EvaluationRating = await _evaluationRatingService.GetEvaluationRatingByEvaluationRatingId(EvaluationRatingId);
            if (EvaluationRating == null)
                return NotFound();

            return Ok(EvaluationRating);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluationRating()
        {
            var allEvaluationRating = await _evaluationRatingService.GetAllEvaluationRating();
            return Ok(allEvaluationRating);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluationRating(EvaluationRatingCUDto EvaluationRating)
        {
            var createdEvaluationRating = await _evaluationRatingService.CreateEvaluationRating(EvaluationRating);
            return CreatedAtAction(nameof(GetEvaluationRatingByEvaluationRatingId), new { createdEvaluationRating.EvaluationRatingId }, createdEvaluationRating);
        }

        [HttpPut("{EvaluationRatingId}")]
        public async Task<IActionResult> UpdateEvaluationRating(EvaluationRatingCUDto EvaluationRating, string EvaluationRatingId)
        {
            await _evaluationRatingService.UpdateEvaluationRating(EvaluationRating, EvaluationRatingId);
            return NoContent();
        }

        [HttpDelete("{EvaluationRatingId}")]
        public async Task<IActionResult> DeleteEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            await _evaluationRatingService.DeleteEvaluationRatingByEvaluationRatingId(EvaluationRatingId);
            return NoContent();
        }
    }
}
