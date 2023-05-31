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

        public AttendanceSummaryController(IAttendanceSummaryService attendanceSummaryService)
        {
            _attendanceSummaryService = attendanceSummaryService;
        }

        [HttpGet("{attendanceSummaryId}")]
        public IActionResult GetAttendanceSummaryByAttendanceSummaryId(string attendanceSummaryId)
        {
            var attendanceSummary = _attendanceSummaryService.GetAttendanceSummaryByAttendanceSummaryId(attendanceSummaryId);
            if (attendanceSummary == null)
                return NotFound();

            return Ok(attendanceSummary);
        }

        [HttpGet]
        public IActionResult GetAllAttendanceSummary()
        {
            var allAttendanceSummary = _attendanceSummaryService.GetAllAttendanceSummary();
            return Ok(allAttendanceSummary);
        }

        [HttpPost]
        public IActionResult CreateattendanceSummary(AttendanceSummaryDto attendanceSummary)
        {
            var createdAttendanceSummary = _attendanceSummaryService.CreateAttendanceSummary(attendanceSummary);
            return CreatedAtAction(nameof(GetAttendanceSummaryByAttendanceSummaryId), new { attendanceSummaryId = createdAttendanceSummary.AttendanceSummaryId }, createdAttendanceSummary);
        }

        [HttpPut("{attendanceSummaryId}")]
        public IActionResult UpdateAttendanceSummary(AttendanceSummaryDto attendanceSummary, string attendanceSummaryId)
        {
            _attendanceSummaryService.UpdateAttendanceSummary(attendanceSummary, attendanceSummaryId);
            return NoContent();
        }

        [HttpDelete("{attendanceSummaryId}")]
        public IActionResult DeleteAttendanceSummary(string attendanceSummaryId)
        {
            _attendanceSummaryService.DeleteAttendanceSummaryByAtendanceSummaryId(attendanceSummaryId);
            return NoContent();
        }
    }
}
