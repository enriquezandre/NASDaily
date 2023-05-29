using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface ILogService
    {
        LogDto CreateLog(LogDto log);
        LogDto GetLogById(string LogId);
        List<LogDto> GetAllLogs();
    }
}