using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;

        public TasksService(ITasksRepository tasksRepository, IMapper mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        public async Task<TasksDto> GetTaskByIdAsync(string taskId)
        {
            var task = await _tasksRepository.GetTaskById(taskId);
            return _mapper.Map<TasksDto>(task);
        }

        public async Task<IEnumerable<TasksDto>> GetAllTasksAsync()
        {
            var tasks = await _tasksRepository.GetAllTasks();
            return _mapper.Map<IEnumerable<TasksDto>>(tasks);
        }

        public async Task UpdateTaskAsync(TasksDto task)
        {
            var mappedTask = _mapper.Map<Tasks>(task);
            await _tasksRepository.UpdateTask(mappedTask);
        }

        public async Task DeleteTaskAsync(string taskId)
        {
            await _tasksRepository.DeleteTask(taskId);
        }
    }
}