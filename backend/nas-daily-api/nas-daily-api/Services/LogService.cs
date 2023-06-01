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
        private readonly INASRepository _nasRepository;
        private readonly IMapper _mapper;

        public LogService(ILogRepository logRepository, IMapper mapper, INASRepository nasRepository)
        {
            _logRepository = logRepository;
            _mapper = mapper;
            _nasRepository = nasRepository;
        }

        public async Task<LogDto> CreateLog(LogDto logDto)
        {
            var log = new Log
            {
                LogId = logDto.LogId,
                TimeIn = logDto.TimeIn,
                TimeOut = logDto.TimeOut,
                Tasks = _mapper.Map<Tasks>(logDto.Tasks)
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
            var nas = await _nasRepository.GetByUserName(userName);
            if (nas == null)
            {
                throw new FileNotFoundException("NAS not found");
            }

            var log = _mapper.Map<Log>(logDto);
            nas.Logs.Add(log);

            await _nasRepository.UpdateNAS(userName, nas);
            await _logRepository.CreateLog(log);
        }

        public async Task UpdateLog(string userName, LogUpdateDto log)
        {
            var logModel = _mapper.Map<Log>(log);
            await _logRepository.UpdateLog(userName, logModel);
        }
    }
}