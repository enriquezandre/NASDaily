using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateLog(LogDto logDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLog = await _logService.CreateLog(logDto);
            return CreatedAtAction(nameof(GetLogById), new { logId = createdLog.LogId }, createdLog);
        }

        [HttpGet("{logId}")]
        public async Task<IActionResult> GetLogById(string logId)
        {
            var log = await _logService.GetLogById(logId);
            if (log == null)
                return NotFound();

            return Ok(log);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _logService.GetAllLogs();
            return Ok(logs);
        }

        [HttpPost("nas/{userName}/logs")]
        public async Task<IActionResult> CreateLogToNas(string userName, LogDto logDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _logService.AddLogToNas(userName, logDto);
            return Ok(logDto);
        }
    }
}