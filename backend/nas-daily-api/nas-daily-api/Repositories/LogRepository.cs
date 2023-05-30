using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<LogDto> _logCollection;

        public LogRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _logCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<LogDto>(options.Value.LogCollectionName);
        }

        public LogDto CreateLog(LogDto log)
        {
            _logCollection.InsertOne(log);
            return log;
        }

        public LogDto GetLogById(string LogId)
        {
            return _logCollection.Find(log => log.LogId == LogId).FirstOrDefault();
        }
        public List<LogDto> GetAllLogs()
        {
            return _logCollection.Find(_ => true).ToList();
        }
    }
}