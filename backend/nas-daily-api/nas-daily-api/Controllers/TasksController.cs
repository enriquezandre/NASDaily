using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;

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

        [HttpPost]
        public IActionResult CreateTask(TasksDto task)
        {
            var createdTask = _tasksService.CreateTask(task);
            return Ok(createdTask);
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTaskById(string taskId)
        {
            var task = _tasksService.GetTaskById(taskId);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _tasksService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPut]
        public IActionResult UpdateTask(TasksDto task)
        {
            _tasksService.UpdateTask(task);
            return Ok();
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(string taskId)
        {
            _tasksService.DeleteTask(taskId);
            return Ok();
        }
    }
}
