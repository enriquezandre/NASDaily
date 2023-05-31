using nas_daily_api.Dtos;
using nas_daily_api.Repositories;

namespace nas_daily_api.Services
{
    public class AttendanceSummaryService : IAttendanceSummaryService
    {
        private readonly IAttendanceSummaryRepository _attendanceSummaryRepository;

        public AttendanceSummaryService(IAttendanceSummaryRepository attendanceSummaryRepository)
        {
            _attendanceSummaryRepository = attendanceSummaryRepository;
        }
        public AttendanceSummaryDto CreateAttendanceSummary(AttendanceSummaryDto attendanceSummary)
        {
            return _attendanceSummaryRepository.Create(attendanceSummary);
        }

        public string DeleteAttendanceSummaryByAtendanceSummaryId(string attendanceSummaryId)
        {
            return _attendanceSummaryRepository.DeleteByAttendanceSummaryId(attendanceSummaryId);
        }

        public List<AttendanceSummaryDto> GetAllAttendanceSummary()
        {
            return _attendanceSummaryRepository.GetAllAttendanceSummary();
        }

        public AttendanceSummaryDto GetAttendanceSummaryByAttendanceSummaryId(string attendanceSummaryId)
        {
            return _attendanceSummaryRepository.GetByAttendanceSummaryId(attendanceSummaryId);
        }

        public void UpdateAttendanceSummary(AttendanceSummaryDto attendanceSummary, string attendanceSummaryId)
        {
            _attendanceSummaryRepository.Update(attendanceSummary, attendanceSummaryId);
        }
    }
}
