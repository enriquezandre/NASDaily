using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class AttendanceSummaryRepository : IAttendanceSummaryRepository
    {
        private readonly IMongoCollection<AttendanceSummary> _attendanceSummaryCollection;

        public AttendanceSummaryRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _attendanceSummaryCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<AttendanceSummary>(options.Value.AttendanceSummaryCollectionName);
        }

        public async Task<AttendanceSummary> Create(AttendanceSummary attendanceSummary)
        {
            await _attendanceSummaryCollection.InsertOneAsync(attendanceSummary);
            return attendanceSummary;
        }

        public async Task<string> DeleteByAttendanceSummaryId(string attendanceSummaryId)
        {
            await _attendanceSummaryCollection.DeleteOneAsync(attendanceSummaryId); 
            return attendanceSummaryId;
        }

        public async Task<IEnumerable<AttendanceSummary>> GetAllAttendanceSummary()
        {
            return await _attendanceSummaryCollection.Find(_ => true).ToListAsync();
        }

        public async Task<AttendanceSummary> GetByAttendanceSummaryId(string attendanceSummaryId)
        {
            return await _attendanceSummaryCollection.Find(absence => absence.AttendanceSummaryId == attendanceSummaryId).FirstOrDefaultAsync();
        }

        public async Task<AttendanceSummary> Update(AttendanceSummary attendanceSummary, string attendanceSummaryId)
        {
            var filter = Builders<AttendanceSummary>.Filter.Eq("AttendanceSummaryId", attendanceSummaryId);
            await _attendanceSummaryCollection.ReplaceOneAsync(filter, attendanceSummary);

            return attendanceSummary;
        }
    }
}
