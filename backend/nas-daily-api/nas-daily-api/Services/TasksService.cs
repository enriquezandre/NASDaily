using nas_daily_api.Dtos;
using nas_daily_api.Repositories;
using System.Collections.Generic;

namespace nas_daily_api.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public TasksDto CreateTask(TasksDto task)
        {
            return _tasksRepository.CreateTask(task);
        }

        public TasksDto GetTaskById(string taskId)
        {
            return _tasksRepository.GetTaskById(taskId);
        }

        public List<TasksDto> GetAllTasks()
        {
            return _tasksRepository.GetAllTasks();
        }

        public void UpdateTask(TasksDto task)
        {
            _tasksRepository.UpdateTask(task);
        }

        public void DeleteTask(string taskId)
        {
            _tasksRepository.DeleteTask(taskId);
        }
    }
}
