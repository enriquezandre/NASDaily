using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class AbsenceService : IAbsenceService
    {

        private readonly IAbsenceRepository _absenceRepository;
        private readonly IMapper _mapper;

        public AbsenceService(IAbsenceRepository absenceRepository, IMapper mapper)
        {
            _absenceRepository = absenceRepository;
            _mapper = mapper;
        }
        public async Task<AbsenceDto> CreateAbsence(AbsenceCreationDto absence)
        {
            var absenceModel = _mapper.Map<Absence>(absence);
            await _absenceRepository.Create(absenceModel);

            return _mapper.Map<AbsenceDto>(absenceModel);
        }

        public async Task<string> DeleteAbsenceByAbsenceId(string absenceId)
        {
            return await _absenceRepository.DeleteByAbsenceId(absenceId);
        }

        public async Task<AbsenceDto?> GetAbsenceByAbsenceId(string absenceId)
        {
            var absenceModel = await _absenceRepository.GetByAbsenceId(absenceId);
            if (absenceModel == null) return null;

            return _mapper.Map<AbsenceDto>(absenceModel);
        }

        public async Task<IEnumerable<AbsenceDto>> GetAllAbsence()
        {
            var absenceList = await _absenceRepository.GetAllAbsence();
            return _mapper.Map<IEnumerable<AbsenceDto>>(absenceList);
        }

        public async Task UpdateAbsence(AbsenceUpdateDto absence, string absenceId)
        {
            var absenceModel = _mapper.Map<Absence>(absence);
            await _absenceRepository.Update(absenceModel, absenceId);
        }
    }
}
