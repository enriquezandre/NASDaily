using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using System.Collections.Generic;

namespace nas_daily_api.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IMongoCollection<ScheduleDto> _scheduleCollection;

        public ScheduleRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _scheduleCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<ScheduleDto>(options.Value.ScheduleCollectionName);
        }

        public ScheduleDto GetScheduleById(string id)
        {
            return _scheduleCollection.Find(schedule => schedule.Id == id).FirstOrDefault();
        }

        public List<ScheduleDto> GetAllSchedules()
        {
            return _scheduleCollection.Find(_ => true).ToList();
        }

        public ScheduleDto CreateSchedule(ScheduleDto schedule)
        {
            _scheduleCollection.InsertOne(schedule);
            return schedule;
        }

        public void UpdateSchedule(string id, ScheduleDto schedule)
        {
            _scheduleCollection.ReplaceOne(schedule => schedule.Id == id, schedule);
        }

        public void DeleteSchedule(string id)
        {
            _scheduleCollection.DeleteOne(schedule => schedule.Id == id);
        }
    }
}