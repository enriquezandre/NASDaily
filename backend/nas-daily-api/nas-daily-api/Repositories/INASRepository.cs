using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface INASRepository
    {
        NASDto GetByNASId(string nasId);
        List<NASDto> GetAllNAS();
        NASCreationDto CreateNAS(NASCreationDto nas);
        void UpdateNAS(string nasId, NASDto nas);
        void DeleteNAS(string nasId);
    }
}