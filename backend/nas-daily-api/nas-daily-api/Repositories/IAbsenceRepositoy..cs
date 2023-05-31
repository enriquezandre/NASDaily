using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IAbsenceRepository
    {
        AbsenceDto GetByAbsenceId(string absenceId);

        string DeleteByAbsenceId(string absenceId);

        AbsenceDto Create(AbsenceDto absence);
        AbsenceDto Update(AbsenceDto absence, string userId);
        List<AbsenceDto> GetAllAbsence();
    }
}
