using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Services
{
    public class NASService : INASService
    {
        private readonly INASRepository _nasRepository;
        private readonly IMapper _mapper;

        public NASService(INASRepository nasRepository, IMapper mapper)
        {
            _nasRepository = nasRepository;
            _mapper = mapper;
        }

        public async Task<NASDto> GetNASByNASId(string nasId)
        {
            var nas = await _nasRepository.GetByNASId(nasId);

            if (nas == null)
                return null;

            var nasDto = _mapper.Map<NASDto>(nas);

            // Filter the Office, Tasks, and Logs based on the provided nasId
            nasDto.Office = _mapper.Map<OfficeDto>(nas.Office);
            nasDto.Tasks = _mapper.Map<List<TasksDto>>(nas.Tasks.Where(t => t.NASId == nasId));
            nasDto.Logs = _mapper.Map<List<LogDto>>(nas.Logs.Where(l => l.NASId == nasId));

            return nasDto;
        }

        public async Task<IEnumerable<NASDto>> GetAllNAS()
        {
            var nasList = await _nasRepository.GetAllNAS();
            return _mapper.Map<IEnumerable<NASDto>>(nasList);
        }

        public async Task<NASDto> CreateNAS(NASDto nas)
        {
            var nasModel = _mapper.Map<NAS>(nas);
            await _nasRepository.CreateNAS(nasModel);
            return _mapper.Map<NASDto>(nasModel);
        }

        public async Task UpdateNAS(string nasId, NASDto nas)
        {
            var nasModel = _mapper.Map<NAS>(nas);
            await _nasRepository.UpdateNAS(nasId, nasModel);
        }

        public async Task DeleteNAS(string nasId)
        {
            await _nasRepository.DeleteNAS(nasId);
        }
    }
}