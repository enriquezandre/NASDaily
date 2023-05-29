using System.Collections.Generic;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface ILogRepository
    {
        LogDto CreateLog(LogDto log);
        LogDto GetLogById(string LogId);
        List<LogDto> GetAllLogs();
    }
}