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

        public EvaluationRatingController(IEvaluationRatingService EvaluationRatingService)
        {
            _evaluationRatingService = EvaluationRatingService;
        }

        [HttpGet("{EvaluationRatingId}")]
        public IActionResult GetEvaluationRatingByEvaluationRatingId(string EvaluationRatingId)
        {
            var EvaluationRating = _evaluationRatingService.GetEvaluationRatingByEvaluationRatingId(EvaluationRatingId);
            if (EvaluationRating == null)
                return NotFound();

            return Ok(EvaluationRating);
        }

        [HttpGet]
        public IActionResult GetAllEvaluationRating()
        {
            var allEvaluationRating = _evaluationRatingService.GetAllEvaluationRating();
            return Ok(allEvaluationRating);
        }

        [HttpPost]
        public IActionResult CreateEvaluationRating(EvaluationRatingDto EvaluationRating)
        {
            var createdEvaluationRating = _evaluationRatingService.CreateEvaluationRating(EvaluationRating);
            return CreatedAtAction(nameof(GetEvaluationRatingByEvaluationRatingId), new { evaluationRatingId = createdEvaluationRating.EvaluationRatingId }, createdEvaluationRating);
        }

        [HttpPut("{EvaluationRatingId}")]
        public IActionResult UpdateEvaluationRating(EvaluationRatingDto EvaluationRating, string EvaluationRatingId)
        {
            _evaluationRatingService.UpdateEvaluationRating(EvaluationRating, EvaluationRatingId);
            return NoContent();
        }

        [HttpDelete("{EvaluationRatingId}")]
        public IActionResult DeleteEvaluationRating(string EvaluationRatingId)
        {
            _evaluationRatingService.DeleteEvaluationRatingByEvaluationRatingId(EvaluationRatingId);
            return NoContent();
        }
    }
}
