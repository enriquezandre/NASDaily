using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public interface IAttendanceSummaryRepository
    {
        Task<AttendanceSummary> GetByAttendanceSummaryId(string attendanceSummaryId);

        Task<string> DeleteByAttendanceSummaryId(string attendanceSummaryId);

        Task<AttendanceSummary> Create(AttendanceSummary attendanceSummary);
        Task<AttendanceSummary> Update(AttendanceSummary attendanceSummary, string userId);
        Task<IEnumerable<AttendanceSummary>> GetAllAttendanceSummary();
    }
}
