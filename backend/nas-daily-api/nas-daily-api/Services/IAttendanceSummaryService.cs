using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IAttendanceSummaryService
    {
        AttendanceSummaryDto GetAttendanceSummaryByAttendanceSummaryId(string attendanceSummaryId);
        string DeleteAttendanceSummaryByAtendanceSummaryId(string attendanceSummaryId);
        List<AttendanceSummaryDto> GetAllAttendanceSummary();
        AttendanceSummaryDto CreateAttendanceSummary(AttendanceSummaryDto attendanceSummary);
        void UpdateAttendanceSummary(AttendanceSummaryDto attendanceSummary, string attendanceSummaryId);
    }
}
