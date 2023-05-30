﻿using System.Collections.Generic;
using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface ITasksService
    {
        TasksDto CreateTask(TasksDto task);
        TasksDto GetTaskById(string taskId);
        List<TasksDto> GetAllTasks();
        void UpdateTask(TasksDto task);
        void DeleteTask(string taskId);
    }
}