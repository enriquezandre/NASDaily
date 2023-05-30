using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IOASService
    {
        OASDto GetOASByUserId(string userId);
        OASDto GetOASByName(string name);
        string DeleteOASByUserId(string userId);
        string DeleteOASByName(string name);
        List<OASDto> GetAllOAS();
        OASDto CreateOAS(OASDto oas);
        void UpdateOAS(OASDto oas, string userId);
    }
}