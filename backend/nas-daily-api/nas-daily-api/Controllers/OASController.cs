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
        private readonly ILogger<OASController> _logger;

        public OASController(IOASService oasService, ILogger<OASController> logger)
        {
            _oasService = oasService;
            _logger = logger;   
        }

        [HttpGet("{oasId}")]
        public async Task<IActionResult> GetOASByOASId(string oasId)
        {
            var oas = await _oasService.GetOASByUserId(oasId);
            if (oas == null)
                return NotFound();

            return Ok(oas);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOAS()
        {
            var alloas = await _oasService.GetAllOAS();
            return Ok(alloas);
        }

        [HttpPost]
        public async Task<IActionResult> Createoas(OASCreationDto oas)
        {
            var createdoas = await _oasService.CreateOAS(oas);
            return CreatedAtAction(nameof(GetOASByOASId), new { OasId = createdoas.OASId }, createdoas);
        }

        [HttpPut("{oasId}")]
        public async Task<IActionResult> Updateoas(OASUpdateDto oas, string oasId)
        {
            await _oasService.UpdateOAS(oas, oasId);
            return NoContent();
        }

        [HttpDelete("{oasId}")]
        public async Task<IActionResult> DeleteOASByOASId(string oasId)
        {
            await _oasService.DeleteOASByUserId(oasId);
            return NoContent();
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteOASByOASName(string name)
        {
            await _oasService.DeleteOASByName(name);
            return NoContent();
        }
    }
}