using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public interface IAbsenceRepository
    {
        Task<Absence> GetByAbsenceId(string absenceId);

        Task<string> DeleteByAbsenceId(string absenceId);

        Task<Absence> Create(Absence absence);
        Task<Absence> Update(Absence absence, string userId);
        Task<IEnumerable<Absence>> GetAllAbsence();
    }
}
