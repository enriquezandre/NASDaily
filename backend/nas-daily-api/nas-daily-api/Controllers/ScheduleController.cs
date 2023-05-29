using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{id}")]
        public IActionResult GetScheduleById(string id)
        {
            var schedule = _scheduleService.GetScheduleById(id);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            var schedules = _scheduleService.GetAllSchedules();
            return Ok(schedules);
        }

        [HttpPost]
        public IActionResult CreateSchedule(ScheduleDto schedule)
        {
            var createdSchedule = _scheduleService.CreateSchedule(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = createdSchedule.Id }, createdSchedule);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(string id, ScheduleDto schedule)
        {
            _scheduleService.UpdateSchedule(id, schedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(string id)
        {
            _scheduleService.DeleteSchedule(id);
            return NoContent();
        }
    }
}