using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/absence")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private readonly IAbsenceService _absenceService;

        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }

        [HttpGet("{absenceId}")]
        public IActionResult GetAbsenceByAbsenceId(string absenceId)
        {
            var absence = _absenceService.GetAbsenceByAbsenceId(absenceId);
            if (absence == null)
                return NotFound();

            return Ok(absence);
        }

        [HttpGet]
        public IActionResult GetAllAbsence()
        {
            var allAbsence = _absenceService.GetAllAbsence();
            return Ok(allAbsence);
        }

        [HttpPost]
        public IActionResult CreateAbsence(AbsenceDto absence)
        {
            var createdAbsence = _absenceService.CreateAbsence(absence);
            return CreatedAtAction(nameof(GetAbsenceByAbsenceId), new { absenceId = createdAbsence.AbsenceId }, createdAbsence);
        }

        [HttpPut("{absenceId}")]
        public IActionResult UpdateAbsence(AbsenceDto absence, string absenceId)
        {
            _absenceService.UpdateAbsence(absence, absenceId);
            return NoContent();
        }

        [HttpDelete("{absenceId}")]
        public IActionResult DeleteAbsence(string absenceId)
        {
            _absenceService.DeleteAbsenceByAbsenceId(absenceId);
            return NoContent();
        }

    }
}
