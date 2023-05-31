using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IAbsenceService
    {
        Task<AbsenceDto?> GetAbsenceByAbsenceId(string absenceId);
        Task<string> DeleteAbsenceByAbsenceId(string absenceId);
        Task<IEnumerable<AbsenceDto>> GetAllAbsence();
        Task<AbsenceDto> CreateAbsence(AbsenceCreationDto absence);
        Task UpdateAbsence(AbsenceUpdateDto absence, string absenceId);
    }
}
