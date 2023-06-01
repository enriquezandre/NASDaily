using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IAttendanceSummaryService
    {
        Task<AttendanceSummaryDto?> GetAttendanceSummaryByAttendanceSummaryId(string attendanceSummaryId);
        Task<string> DeleteAttendanceSummaryByAtendanceSummaryId(string attendanceSummaryId);
        Task<IEnumerable<AttendanceSummaryDto>> GetAllAttendanceSummary();
        Task<AttendanceSummaryDto> CreateAttendanceSummary(AttendanceSummaryCUDto attendanceSummary);
        Task UpdateAttendanceSummary(AttendanceSummaryCUDto attendanceSummary, string attendanceSummaryId);
    }
}
