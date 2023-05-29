using nas_daily_api.Dtos;
using System.Collections.Generic;

namespace nas_daily_api.Services
{
    public interface IScheduleService
    {
        ScheduleDto GetScheduleById(string id);
        List<ScheduleDto> GetAllSchedules();
        ScheduleDto CreateSchedule(ScheduleDto schedule);
        void UpdateSchedule(string id, ScheduleDto schedule);
        void DeleteSchedule(string id);
    }
}