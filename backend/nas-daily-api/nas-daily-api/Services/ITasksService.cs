using System.Collections.Generic;
using System.Threading.Tasks;
using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface ITasksService
    {
        Task<TasksDto> CreateTaskAsync(TasksDto task);
        Task<TasksDto> GetTaskByIdAsync(string taskId);
        Task<IEnumerable<TasksDto>> GetAllTasksAsync();
        Task UpdateTaskAsync(TasksDto task);
        Task DeleteTaskAsync(string taskId);
    }
}