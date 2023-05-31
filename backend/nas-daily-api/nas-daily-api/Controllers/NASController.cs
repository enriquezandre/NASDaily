using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;
using System.Threading.Tasks;

namespace nas_daily_api.Controllers
{
    [Route("api/nas")]
    [ApiController]
    public class NASController : ControllerBase
    {
        private readonly INASService _nasService;
        private readonly ILogger<NASController> _logger;

        public NASController(INASService nasService, ILogger<NASController> logger)
        {
            _nasService = nasService;
            _logger = logger;
        }

        [HttpGet("{nasId}")]
        public async Task<IActionResult> GetNASByNASId(string nasId)
        {
            var nas = await _nasService.GetNASByNASId(nasId);
            if (nas == null)
                return NotFound();

            return Ok(nas);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNAS()
        {
            var allNAS = await _nasService.GetAllNAS();
            return Ok(allNAS);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNAS(NASDto nas)
        {
            var createdNAS = await _nasService.CreateNAS(nas);
            return CreatedAtAction(nameof(GetNASByNASId), new { nasId = createdNAS.NASId }, createdNAS);
        }

        [HttpPut("{nasId}")]
        public async Task<IActionResult> UpdateNAS(string nasId, NASDto nas)
        {
            await _nasService.UpdateNAS(nasId, nas);
            return NoContent();
        }

        [HttpDelete("{nasId}")]
        public async Task<IActionResult> DeleteNAS(string nasId)
        {
            await _nasService.DeleteNAS(nasId);
            return NoContent();
        }
    }
}