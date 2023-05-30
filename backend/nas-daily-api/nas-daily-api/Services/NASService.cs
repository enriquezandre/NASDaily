using nas_daily_api.Dtos;
using nas_daily_api.Repositories;
using System.Collections.Generic;

namespace nas_daily_api.Services
{
    public class NASService : INASService
    {
        private readonly INASRepository _nasRepository;

        public NASService(INASRepository nasRepository)
        {
            _nasRepository = nasRepository;
        }

        public NASDto GetNASByNASId(string nasId)
        {
            return _nasRepository.GetByNASId(nasId);
        }

        public List<NASDto> GetAllNAS()
        {
            return _nasRepository.GetAllNAS();
        }

        public NASDto CreateNAS(NASDto nas)
        {
            return _nasRepository.CreateNAS(nas);
        }

        public void UpdateNAS(string nasId, NASDto nas)
        {
            _nasRepository.UpdateNAS(nasId, nas);
        }

        public void DeleteNAS(string nasId)
        {
            _nasRepository.DeleteNAS(nasId);
        }
    }
}