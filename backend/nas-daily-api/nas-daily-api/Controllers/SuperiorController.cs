using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/superior")]
    [ApiController]
    public class SuperiorController : ControllerBase
    {
        private readonly ISuperiorService _superiorService;

        public SuperiorController(ISuperiorService superiorService)
        {
            _superiorService = superiorService;
        }

        [HttpGet("{superiorId}")]
        public IActionResult GetSuperiorBySuperiorId(string superiorId)
        {
            var superior = _superiorService.GetSuperiorBySuperiorId(superiorId);
            if (superior == null)
                return NotFound();

            return Ok(superior);
        }

        [HttpGet]
        public IActionResult GetAllSuperiors()
        {
            var allSuperiors = _superiorService.GetAllSuperiors();
            return Ok(allSuperiors);
        }

        [HttpPost]
        public IActionResult CreateSuperior(SuperiorDto superior)
        {
            var createdSuperior = _superiorService.CreateSuperior(superior);
            return CreatedAtAction(nameof(GetSuperiorBySuperiorId), new { superiorId = createdSuperior.SuperiorId }, createdSuperior);
        }

        [HttpPut("{superiorId}")]
        public IActionResult UpdateSuperior(string superiorId, SuperiorDto superior)
        {
            _superiorService.UpdateSuperior(superiorId, superior);
            return NoContent();
        }

        [HttpDelete("{superiorId}")]
        public IActionResult DeleteSuperior(string superiorId)
        {
            _superiorService.DeleteSuperior(superiorId);
            return NoContent();
        }
    }
}