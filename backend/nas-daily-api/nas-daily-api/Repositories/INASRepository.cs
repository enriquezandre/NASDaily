using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface INASRepository
    {
        NASDto GetByNASId(string nasId);
        List<NASDto> GetAllNAS();
        NASDto CreateNAS(NASDto nas);
        void UpdateNAS(string nasId, NASDto nas);
        void DeleteNAS(string nasId);
    }
}