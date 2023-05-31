using nas_daily_api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Services
{
    public interface ILogService
    {
        Task<LogDto> CreateLog(LogDto log);
        Task<LogDto> GetLogById(string logId);
        Task<IEnumerable<LogDto>> GetAllLogs();
        Task AddLogToNas(string userName, LogDto logDto);
        Task UpdateLog(string logId, LogUpdateDto log);
    }
}