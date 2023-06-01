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
        private readonly ILogger<AbsenceController> _logger;

        public AbsenceController(IAbsenceService AbsenceService, ILogger<AbsenceController> logger)
        {
            _absenceService = AbsenceService;
            _logger = logger;
        }

        [HttpGet("{AbsenceId}")]
        public async Task<IActionResult> GetAbsenceByAbsenceId(string AbsenceId)
        {
            var Absence = await _absenceService.GetAbsenceByAbsenceId(AbsenceId);
            if (Absence == null)
                return NotFound();

            return Ok(Absence);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbsence()
        {
            var allAbsence = await _absenceService.GetAllAbsence();
            return Ok(allAbsence);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbsence(AbsenceCreationDto Absence)
        {
            var createdAbsence = await _absenceService.CreateAbsence(Absence);
            return CreatedAtAction(nameof(GetAbsenceByAbsenceId), new { createdAbsence.AbsenceId }, createdAbsence);
        }

        [HttpPut("{AbsenceId}")]
        public async Task<IActionResult> UpdateAbsence(AbsenceUpdateDto Absence, string AbsenceId)
        {
            await _absenceService.UpdateAbsence(Absence, AbsenceId);
            return NoContent();
        }

        [HttpDelete("{AbsenceId}")]
        public async Task<IActionResult> DeleteAbsenceByAbsenceId(string AbsenceId)
        {
            await _absenceService.DeleteAbsenceByAbsenceId(AbsenceId);
            return NoContent();
        }

    }
}
