using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class AttendanceSummaryRepository : IAttendanceSummaryRepository
    {
        private readonly IMongoCollection<AttendanceSummaryDto> _attendanceSummaryCollection;

        public AttendanceSummaryRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _attendanceSummaryCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<AttendanceSummaryDto>(options.Value.AttendanceSummaryCollectionName);
        }

        public AttendanceSummaryDto Create(AttendanceSummaryDto attendanceSummary)
        {
            _attendanceSummaryCollection.InsertOne(attendanceSummary);
            return attendanceSummary;
        }

        public string DeleteByAttendanceSummaryId(string attendanceSummaryId)
        {
            _attendanceSummaryCollection.DeleteOne(attendanceSummaryId); 
            return attendanceSummaryId;
        }

        public List<AttendanceSummaryDto> GetAllAttendanceSummary()
        {
            return _attendanceSummaryCollection.Find(_ => true).ToList();
        }

        public AttendanceSummaryDto GetByAttendanceSummaryId(string attendanceSummaryId)
        {
            return _attendanceSummaryCollection.Find(absence => absence.AttendanceSummaryId == attendanceSummaryId).FirstOrDefault();
        }

        public AttendanceSummaryDto Update(AttendanceSummaryDto attendanceSummary, string attendanceSummaryId)
        {
            var filter = Builders<AttendanceSummaryDto>.Filter.Eq("AttendanceSummaryId", attendanceSummaryId);
            _attendanceSummaryCollection.ReplaceOne(filter, attendanceSummary);

            return attendanceSummary;
        }
    }
}
