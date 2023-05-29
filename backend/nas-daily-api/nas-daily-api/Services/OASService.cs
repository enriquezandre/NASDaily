﻿using System.Xml.Linq;
using nas_daily_api.Dtos;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class OASService : IOASService
    {
        private readonly IOASRepository _oasRepository;

        public OASService(IOASRepository oasRepository)
        {
            _oasRepository = oasRepository;
        }

        public OASDto CreateOAS(OASDto oas)
        {
            return _oasRepository.Create(oas);
        }

        public string DeleteOASByUserId(string userId)
        {
            return _oasRepository.DeleteByUserId(userId);
        }

        public string DelteOASByName(string name)
        {
            return _oasRepository.DeleteByName(name);
        }

        public List<OASDto> GetAllOAS()
        {
            return _oasRepository.GetAllOAS();
        }

        public OASDto GetOASByName(string name)
        {
            return _oasRepository.GetByUserId(name);
        }

        public OASDto GetOASByUserId(string userId)
        {
            return _oasRepository.GetByUserId(userId);
        }

        public void UpdateOAS(OASDto oas, string userId)
        {
            return _oasRepository.Update(oas, userId);
        }

        // Add more methods as per your requirements
    }
}