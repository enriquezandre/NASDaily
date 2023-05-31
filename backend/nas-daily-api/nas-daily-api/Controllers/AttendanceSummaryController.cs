using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/attendanceSummary")]
    [ApiController]
    public class AttendanceSummaryController : ControllerBase
    {
        private readonly IAttendanceSummaryService _attendanceSummaryService;
        private readonly ILogger<AttendanceSummaryController> _logger;

        public AttendanceSummaryController(IAttendanceSummaryService AttendanceSummaryService, ILogger<AttendanceSummaryController> logger)
        {
            _attendanceSummaryService = AttendanceSummaryService;
            _logger = logger;
        }

        [HttpGet("{AttendanceSummaryId}")]
        public async Task<IActionResult> GetAttendanceSummaryByAttendanceSummaryId(string AttendanceSummaryId)
        {
            var AttendanceSummary = await _attendanceSummaryService.GetAttendanceSummaryByAttendanceSummaryId(AttendanceSummaryId);
            if (AttendanceSummary == null)
                return NotFound();

            return Ok(AttendanceSummary);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendanceSummary()
        {
            var allAttendanceSummary = await _attendanceSummaryService.GetAllAttendanceSummary();
            return Ok(allAttendanceSummary);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendanceSummary(AttendanceSummaryCUDto AttendanceSummary)
        {
            var createdAttendanceSummary = await _attendanceSummaryService.CreateAttendanceSummary(AttendanceSummary);
            return CreatedAtAction(nameof(GetAttendanceSummaryByAttendanceSummaryId), new { createdAttendanceSummary.AttendanceSummaryId }, createdAttendanceSummary);
        }

        [HttpPut("{AttendanceSummaryId}")]
        public async Task<IActionResult> UpdateAttendanceSummary(AttendanceSummaryCUDto AttendanceSummary, string AttendanceSummaryId)
        {
            await _attendanceSummaryService.UpdateAttendanceSummary(AttendanceSummary, AttendanceSummaryId);
            return NoContent();
        }

        [HttpDelete("{AttendanceSummaryId}")]
        public async Task<IActionResult> DeleteAttendanceSummaryByAttendanceSummaryId(string AttendanceSummaryId)
        {
            await _attendanceSummaryService.DeleteAttendanceSummaryByAtendanceSummaryId(AttendanceSummaryId);
            return NoContent();
        }
    }
}
