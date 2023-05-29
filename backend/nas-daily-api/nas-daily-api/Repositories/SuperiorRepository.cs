using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public class SuperiorRepository : ISuperiorRepository
    {
        private readonly IMongoCollection<SuperiorDto> _superiorCollection;

        public SuperiorRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _superiorCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<SuperiorDto>(options.Value.SuperiorCollectionName);
        }

        public SuperiorDto GetBySuperiorId(string superiorId)
        {
            return _superiorCollection.Find(superior => superior.SuperiorId == superiorId).FirstOrDefault();
        }

        public List<SuperiorDto> GetAllSuperiors()
        {
            return _superiorCollection.Find(_ => true).ToList();
        }

        public SuperiorDto CreateSuperior(SuperiorDto superior)
        {
            _superiorCollection.InsertOne(superior);
            return superior;
        }

        public void UpdateSuperior(string superiorId, SuperiorDto superior)
        {
            _superiorCollection.ReplaceOne(s => s.SuperiorId == superiorId, superior);
        }

        public void DeleteSuperior(string superiorId)
        {
            _superiorCollection.DeleteOne(s => s.SuperiorId == superiorId);
        }
    }
}