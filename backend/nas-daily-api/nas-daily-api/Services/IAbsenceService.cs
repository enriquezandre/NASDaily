using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IAbsenceService
    {
        AbsenceDto GetAbsenceByAbsenceId(string absenceId);
        string DeleteAbsenceByAbsenceId(string absenceId);
        List<AbsenceDto> GetAllAbsence();
        AbsenceDto CreateAbsence(AbsenceDto absence);
        void UpdateAbsence(AbsenceDto absence, string absenceId);
    }
}
