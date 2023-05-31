using AutoMapper;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class AttendanceSummaryService : IAttendanceSummaryService
    {
        private readonly IAttendanceSummaryRepository _attendanceSummaryRepository;
        private readonly IMapper _mapper;

        public AttendanceSummaryService(IAttendanceSummaryRepository AttendanceSummaryRepository, IMapper mapper)
        {
            _attendanceSummaryRepository = AttendanceSummaryRepository;
            _mapper = mapper;
        }
        public async Task<AttendanceSummaryDto> CreateAttendanceSummary(AttendanceSummaryCUDto AttendanceSummary)
        {
            var AttendanceSummaryModel = _mapper.Map<AttendanceSummary>(AttendanceSummary);
            await _attendanceSummaryRepository.Create(AttendanceSummaryModel);

            return _mapper.Map<AttendanceSummaryDto>(AttendanceSummaryModel);
        }

        public async Task<string> DeleteAttendanceSummaryByAtendanceSummaryId(string AttendanceSummaryId)
        {
            return await _attendanceSummaryRepository.DeleteByAttendanceSummaryId(AttendanceSummaryId);
        }

        public async Task<AttendanceSummaryDto?> GetAttendanceSummaryByAttendanceSummaryId(string AttendanceSummaryId)
        {
            var AttendanceSummaryModel = await _attendanceSummaryRepository.GetByAttendanceSummaryId(AttendanceSummaryId);
            if (AttendanceSummaryModel == null) return null;

            return _mapper.Map<AttendanceSummaryDto>(AttendanceSummaryModel);
        }

        public async Task<IEnumerable<AttendanceSummaryDto>> GetAllAttendanceSummary()
        {
            var AttendanceSummaryList = await _attendanceSummaryRepository.GetAllAttendanceSummary();
            return _mapper.Map<IEnumerable<AttendanceSummaryDto>>(AttendanceSummaryList);
        }

        public async Task UpdateAttendanceSummary(AttendanceSummaryCUDto AttendanceSummary, string AttendanceSummaryId)
        {
            var AttendanceSummaryModel = _mapper.Map<AttendanceSummary>(AttendanceSummary);
            await _attendanceSummaryRepository.Update(AttendanceSummaryModel, AttendanceSummaryId);
        }
    }
}
