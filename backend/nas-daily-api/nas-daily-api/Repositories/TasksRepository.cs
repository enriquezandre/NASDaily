using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using System.Collections.Generic;

namespace nas_daily_api.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IMongoCollection<TasksDto> _tasksCollection;

        public TasksRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _tasksCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<TasksDto>(options.Value.TasksCollectionName);
        }

        public TasksDto CreateTask(TasksDto task)
        {
            _tasksCollection.InsertOne(task);
            return task;
        }

        public TasksDto GetTaskById(string taskId)
        {
            return _tasksCollection.Find(task => task.TaskId == taskId).FirstOrDefault();
        }

        public List<TasksDto> GetAllTasks()
        {
            return _tasksCollection.Find(_ => true).ToList();
        }

        public void UpdateTask(TasksDto task)
        {
            var filter = Builders<TasksDto>.Filter.Eq(t => t.TaskId, task.TaskId);
            _tasksCollection.ReplaceOne(filter, task);
        }

        public void DeleteTask(string taskId)
        {
            var filter = Builders<TasksDto>.Filter.Eq(t => t.TaskId, taskId);
            _tasksCollection.DeleteOne(filter);
        }
    }
}