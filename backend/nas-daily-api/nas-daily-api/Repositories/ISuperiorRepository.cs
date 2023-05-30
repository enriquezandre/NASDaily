using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface ISuperiorRepository
    {
        SuperiorDto GetBySuperiorId(string superiorId);
        List<SuperiorDto> GetAllSuperiors();
        SuperiorDto CreateSuperior(SuperiorDto superior);
        void UpdateSuperior(string superiorId, SuperiorDto superior);
        void DeleteSuperior(string superiorId);
    }
}