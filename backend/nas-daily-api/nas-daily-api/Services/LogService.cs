using nas_daily_api.Dtos;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public LogDto CreateLog(LogDto log)
        {
            return _logRepository.CreateLog(log);
        }

        public LogDto GetLogById(string LogId)
        {
            return _logRepository.GetLogById(LogId);
        }
        public List<LogDto> GetAllLogs()
        {
            return _logRepository.GetAllLogs();
        }
    }
}