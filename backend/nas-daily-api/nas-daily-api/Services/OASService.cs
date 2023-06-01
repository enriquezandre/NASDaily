using System.Xml.Linq;
using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class OASService : IOASService
    {
        private readonly IOASRepository _oasRepository;
        private readonly IMapper _mapper;

        public OASService(IOASRepository oasRepository, IMapper mapper)
        {
            _oasRepository = oasRepository;
            _mapper = mapper;
        }

        public async Task<OASDto?> GetOASByUserId(string userId)
        {
            var oasModel = await _oasRepository.GetByUserId(userId);
            if (oasModel == null) return null;

            return _mapper.Map<OASDto>(oasModel);
        }

        public async Task<OASDto?> GetOASByName(string name)
        {
            var oasModel = await _oasRepository.GetByName(name);
            if (oasModel == null) return null;

            return _mapper.Map<OASDto>(oasModel);
        }

        public async Task<string> DeleteOASByUserId(string userId)
        {
            return await _oasRepository.DeleteByUserId(userId);
        }

        public async Task<string> DeleteOASByName(string name)
        {
            return await _oasRepository.DeleteByName(name);
        }

        public async Task<IEnumerable<OASDto>> GetAllOAS()
        {
            var oasList = await _oasRepository.GetAllOAS();
            return _mapper.Map<IEnumerable<OASDto>>(oasList);
        }

        public async Task<OASDto> CreateOAS(OASCreationDto oas)
        {
            var oasModel = _mapper.Map<OAS>(oas);
            await _oasRepository.Create(oasModel);

            return _mapper.Map<OASDto>(oasModel);
        }

        public async Task UpdateOAS(OASUpdateDto oas, string userId)
        {
            var oasModel = _mapper.Map<OAS>(oas);
            await _oasRepository.Update(oasModel, userId);
        }
    }
}