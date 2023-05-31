using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<NASDto>> GetAllNAS()
        {
            var nasList = await _nasRepository.GetAllNAS();
            return _mapper.Map<IEnumerable<NASDto>>(nasList);
        }
        public async Task<NASDto> GetByNASId(string nasId)
        {
            var nas = await _nasRepository.GetByNASId(nasId);
            return _mapper.Map<NASDto>(nas);
        }
        public async Task<NASDto> GetByUserName(string userName)
        {
            var nas = await _nasRepository.GetByUserName(userName);
            return _mapper.Map<NASDto>(nas);
        }

        public async Task<NASDto> CreateNAS(NASCreationDto nasCreationDto)
        {
            var nasModel = _mapper.Map<NAS>(nasCreationDto);
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