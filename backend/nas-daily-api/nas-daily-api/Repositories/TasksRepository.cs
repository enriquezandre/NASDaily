using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IMongoCollection<Tasks> _tasksCollection;

        public TasksRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _tasksCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Tasks>(options.Value.TasksCollectionName);
        }

        public async Task<Tasks> GetTaskById(string taskId)
        {
            return await _tasksCollection.Find(task => task.TaskId == taskId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return await _tasksCollection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateTask(Tasks task)
        {
            await _tasksCollection.ReplaceOneAsync(t => t.TaskId == task.TaskId, task);
        }

        public async Task DeleteTask(string taskId)
        {
            await _tasksCollection.DeleteOneAsync(task => task.TaskId == taskId);
        }
    }
}