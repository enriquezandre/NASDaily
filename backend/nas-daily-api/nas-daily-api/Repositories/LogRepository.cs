using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logCollection;
        private readonly IMongoCollection<Tasks> _taskCollection;
        private readonly IMongoCollection<NAS> _nasCollection;

        public LogRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _logCollection = database.GetCollection<Log>(options.Value.LogCollectionName);
            _taskCollection = database.GetCollection<Tasks>(options.Value.TasksCollectionName);
            _nasCollection = database.GetCollection<NAS>(options.Value.NASCollectionName);
        }

        public async Task<Log> CreateLog(Log log)
        {
            log.Id = ObjectId.GenerateNewId().ToString();
            await _logCollection.InsertOneAsync(log);
            var task = new Tasks
            {
                TaskId = log.Tasks.TaskId,
                ActivitiesDone = log.Tasks.ActivitiesDone,
                SkillsLearned = log.Tasks.SkillsLearned,
                ValuesLearned = log.Tasks.ValuesLearned
            };

            await _taskCollection.InsertOneAsync(task);
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
        public async Task AddLogToNas(string userName, Log log)
        {
            var filter = Builders<NAS>.Filter.Eq("Username", userName);
            var update = Builders<NAS>.Update.Push("Logs", log);

            await _nasCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Log> UpdateLog(string logId, Log log)
        {
            var filter = Builders<Log>.Filter.Eq("LogId", logId);
            await _logCollection.ReplaceOneAsync(filter, log);

            return log;
        }
    }
}