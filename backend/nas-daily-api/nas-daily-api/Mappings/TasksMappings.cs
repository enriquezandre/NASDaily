using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Mappings
{
    public class TasksMappings:Profile
    {
        public TasksMappings()
        {
            CreateMap<Tasks, TasksDto>();
            CreateMap<TasksDto, Tasks>();
        }
    }
}
