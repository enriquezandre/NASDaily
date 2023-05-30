using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/oas")]
    [ApiController]
    public class OASController : ControllerBase
    {
        private readonly IOASService _oasService;

        public OASController(IOASService oasService)
        {
            _oasService = oasService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetOASByOASId(string userId)
        {
            var oas = _oasService.GetOASByUserId(userId);
            if (oas == null)
                return NotFound();

            return Ok(oas);
        }

        [HttpGet]
        public IActionResult GetAllOAS()
        {
            var allOAS = _oasService.GetAllOAS();
            return Ok(allOAS);
        }

        [HttpPost]
        public IActionResult CreateOAS(OASDto oas)
        {
            var createdOAS = _oasService.CreateOAS(oas);
            return CreatedAtAction(nameof(GetOASByOASId), new { oasId = createdOAS.UserId }, createdOAS);
        }

        [HttpPut("{oasId}")]
        public IActionResult Updateoas(OASDto oas, string oasId)
        {
            _oasService.UpdateOAS(oas, oasId);
            return NoContent();
        }

        [HttpDelete("{oasId}")]
        public IActionResult DeleteOAS(string oasId)
        {
            _oasService.DeleteOASByUserId(oasId);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteOASByName(string name)
        {
            _oasService.DeleteOASByName(name);
            return NoContent();
        }
    }
}