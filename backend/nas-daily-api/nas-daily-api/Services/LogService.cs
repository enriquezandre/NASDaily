using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogService(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<LogDto> CreateLog(LogDto logDto)
        {
            var log = new Log
            {
                LogId = logDto.LogId,
                TimeIn = logDto.TimeIn,
                TimeOut = logDto.TimeOut
            };

            await _logRepository.CreateLog(log);
            return _mapper.Map<LogDto>(log);
        }

        public async Task<LogDto> GetLogById(string logId)
        {
            var log = await _logRepository.GetLogById(logId);
            return _mapper.Map<LogDto>(log);
        }

        public async Task<IEnumerable<LogDto>> GetAllLogs()
        {
            var logs = await _logRepository.GetAllLogs();
            return _mapper.Map<IEnumerable<LogDto>>(logs);
        }
        public async Task AddLogToNas(string userName, LogDto logDto)
        {
            var log = _mapper.Map<Log>(logDto);
            await _logRepository.AddLogToNas(userName, log);
        }

        public async Task UpdateLog(string userName, LogUpdateDto log)
        {
            var logModel = _mapper.Map<Log>(log);
            await _logRepository.UpdateLog(userName, logModel);
        }
    }
}