using nas_daily_api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Services
{
    public interface INASService
    {
        Task<NASDto> GetNASByNASId(string nasId);
        Task<IEnumerable<NASDto>> GetAllNAS();
        Task<NASDto> CreateNAS(NASDto nas);
        Task UpdateNAS(string nasId, NASDto nas);
        Task DeleteNAS(string nasId);
    }
}