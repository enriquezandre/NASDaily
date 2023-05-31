using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Services;
using System.Threading.Tasks;

namespace nas_daily_api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(string taskId)
        {
            var task = await _tasksService.GetTaskByIdAsync(taskId);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TasksDto task)
        {
            await _tasksService.UpdateTaskAsync(task);
            return Ok();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(string taskId)
        {
            await _tasksService.DeleteTaskAsync(taskId);
            return Ok();
        }
    }
}