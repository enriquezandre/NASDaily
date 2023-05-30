using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

namespace nas_daily_api.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public IActionResult CreateLog(LogDto log)
        {
            var createdLog = _logService.CreateLog(log);
            return CreatedAtAction(nameof(GetLogById), new { LogId = createdLog.Id }, createdLog);
        }

        [HttpGet("{LogId}")]
        public IActionResult GetLogById(string LogId)
        {
            var log = _logService.GetLogById(LogId);
            if (log == null)
                return NotFound();

            return Ok(log);
        }
        [HttpGet]
        public IActionResult GetAllLogs()
        {
            var logs = _logService.GetAllLogs();
            return Ok(logs);
        }
    }
}