using nas_daily_api.Dtos;
using nas_daily_api.Repositories;
using System.Collections.Generic;

namespace nas_daily_api.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ScheduleDto GetScheduleById(string id)
        {
            return _scheduleRepository.GetScheduleById(id);
        }

        public List<ScheduleDto> GetAllSchedules()
        {
            return _scheduleRepository.GetAllSchedules();
        }

        public ScheduleDto CreateSchedule(ScheduleDto schedule)
        {
            return _scheduleRepository.CreateSchedule(schedule);
        }

        public void UpdateSchedule(string id, ScheduleDto schedule)
        {
            _scheduleRepository.UpdateSchedule(id, schedule);
        }

        public void DeleteSchedule(string id)
        {
            _scheduleRepository.DeleteSchedule(id);
        }
    }
}