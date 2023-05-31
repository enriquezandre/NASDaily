using nas_daily_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Repositories
{
    public interface INASRepository
    {
        Task<NAS> GetByNASId(string nasId);
        Task<List<NAS>> GetAllNAS();
        Task<NAS> GetByUserName(string userName);
        Task<NAS> CreateNAS(NAS nas);
        Task UpdateNAS(string user, NAS nas);
        Task DeleteNAS(string nasId);
    }
}