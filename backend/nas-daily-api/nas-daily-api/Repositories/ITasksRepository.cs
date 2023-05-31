using nas_daily_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Repositories
{
    public interface ITasksRepository
    {
        Task<Tasks> GetTaskById(string taskId);
        Task<IEnumerable<Tasks>> GetAllTasks();
        Task UpdateTask(Tasks task);
        Task DeleteTask(string taskId);
    }
}