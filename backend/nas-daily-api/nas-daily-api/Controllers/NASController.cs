using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/nas")]
    [ApiController]
    public class NASController : ControllerBase
    {
        private readonly INASService _nasService;

        public NASController(INASService nasService)
        {
            _nasService = nasService;
        }

        [HttpGet("{nasId}")]
        public IActionResult GetNASByNASId(string nasId)
        {
            var nas = _nasService.GetNASByNASId(nasId);
            if (nas == null)
                return NotFound();

            return Ok(nas);
        }

        [HttpGet]
        public IActionResult GetAllNAS()
        {
            var allNAS = _nasService.GetAllNAS();
            return Ok(allNAS);
        }

        [HttpPost]
        public IActionResult CreateNAS(NASDto nas)
        {
            var createdNAS = _nasService.CreateNAS(nas);
            return CreatedAtAction(nameof(GetNASByNASId), new { nasId = createdNAS.NASId }, createdNAS);
        }

        [HttpPut("{nasId}")]
        public IActionResult UpdateNAS(string nasId, NASDto nas)
        {
            _nasService.UpdateNAS(nasId, nas);
            return NoContent();
        }

        [HttpDelete("{nasId}")]
        public IActionResult DeleteNAS(string nasId)
        {
            _nasService.DeleteNAS(nasId);
            return NoContent();
        }
    }
}