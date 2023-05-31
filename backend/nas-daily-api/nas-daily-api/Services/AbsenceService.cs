using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class AbsenceService : IAbsenceService
    {

        private readonly IAbsenceRepository _absenceRepository;

        public AbsenceService(IAbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;
        }
        public AbsenceDto CreateAbsence(AbsenceDto absence)
        {
            return _absenceRepository.Create(absence);
        }

        public string DeleteAbsenceByAbsenceId(string absenceId)
        {
            return _absenceRepository.DeleteByAbsenceId(absenceId);
        }

        public AbsenceDto GetAbsenceByAbsenceId(string absenceId)
        {
            return _absenceRepository.GetByAbsenceId(absenceId);
        }

        public List<AbsenceDto> GetAllAbsence()
        {
            return _absenceRepository.GetAllAbsence();
        }

        public void UpdateAbsence(AbsenceDto absence, string absenceId)
        {
            _absenceRepository.Update(absence, absenceId);
        }
    }
}
