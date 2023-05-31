using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logCollection;

        public LogRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _logCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Log>(options.Value.LogCollectionName);
        }

        public async Task<Log> CreateLog(Log log)
        {
            await _logCollection.InsertOneAsync(log);
            return log;
        }

        public async Task<Log> GetLogById(string logId)
        {
            return await _logCollection.Find(log => log.LogId == logId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Log>> GetAllLogs()
        {
            return await _logCollection.Find(_ => true).ToListAsync();
        }
    }
}