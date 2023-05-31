using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IAttendanceSummaryRepository
    {
        AttendanceSummaryDto GetByAttendanceSummaryId(string attendanceSummaryId);

        string DeleteByAttendanceSummaryId(string attendanceSummaryId);

        AttendanceSummaryDto Create(AttendanceSummaryDto attendanceSummary);
        AttendanceSummaryDto Update(AttendanceSummaryDto attendanceSummary, string userId);
        List<AttendanceSummaryDto> GetAllAttendanceSummary();
    }
}
