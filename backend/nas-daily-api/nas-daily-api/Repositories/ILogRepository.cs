using System.Collections.Generic;
using System.Threading.Tasks;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public interface ILogRepository
    {
        Task<Log> CreateLog(Log log);
        Task<Log> GetLogById(string logId);
        Task<IEnumerable<Log>> GetAllLogs();
    }
}