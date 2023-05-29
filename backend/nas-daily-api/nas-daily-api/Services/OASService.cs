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

        public OASDto GetOASByUserId(string userId)
        {
            return _oasRepository.GetByUserId(userId);
        }

        // Add more methods as per your requirements
    }
}