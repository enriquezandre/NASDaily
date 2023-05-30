using nas_daily_api.Dtos;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class SuperiorService : ISuperiorService
    {
        private readonly ISuperiorRepository _superiorRepository;

        public SuperiorService(ISuperiorRepository superiorRepository)
        {
            _superiorRepository = superiorRepository;
        }

        public SuperiorDto GetSuperiorBySuperiorId(string superiorId)
        {
            return _superiorRepository.GetBySuperiorId(superiorId);
        }

        public List<SuperiorDto> GetAllSuperiors()
        {
            return _superiorRepository.GetAllSuperiors();
        }

        public SuperiorDto CreateSuperior(SuperiorDto superior)
        {
            return _superiorRepository.CreateSuperior(superior);
        }

        public void UpdateSuperior(string superiorId, SuperiorDto superior)
        {
            _superiorRepository.UpdateSuperior(superiorId, superior);
        }

        public void DeleteSuperior(string superiorId)
        {
            _superiorRepository.DeleteSuperior(superiorId);
        }
    }
}