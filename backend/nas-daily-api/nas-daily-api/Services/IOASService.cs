using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IOASService
    {
        Task<OASDto?> GetOASByUserId(string userId);
        Task<OASDto?> GetOASByName(string name);
        Task<string> DeleteOASByUserId(string userId);
        Task<string> DeleteOASByName(string name);
        Task<IEnumerable<OASDto>> GetAllOAS();
        Task<OASDto> CreateOAS(OASCreationDto oas);
        Task UpdateOAS(OASUpdateDto oas, string userId);
    }
}