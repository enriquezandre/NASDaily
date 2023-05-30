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
        public IActionResult GetOASByUserId(string userId)
        {
            var oas = _oasService.GetOASByUserId(userId);
            if (oas == null)
                return NotFound();

            return Ok(oas);
        }
    }
}