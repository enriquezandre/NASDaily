using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public interface IOASRepository
    {
        Task<OAS> GetByUserId(string userId);
        Task<OAS> GetByName(string name);

        Task<string> DeleteByUserId(string userId);
        Task<string> DeleteByName(string name);

        Task<OAS> Create(OAS oas);
        Task<OAS> Update(OAS oas, string userId);
        Task<IEnumerable<OAS>> GetAllOAS();
    }
}