using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public class NASRepository : INASRepository
    {
        private readonly IMongoCollection<NASDto> _nasCollection;

        public NASRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _nasCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<NASDto>(options.Value.NASCollectionName);
        }

        public NASDto GetByNASId(string nasId)
        {
            return _nasCollection.Find(nas => nas.NASId == nasId).FirstOrDefault();
        }

        public List<NASDto> GetAllNAS()
        {
            return _nasCollection.Find(_ => true).ToList();
        }

        public NASCreationDto CreateNAS(NASCreationDto nas)
        {
            _nasCollection.InsertOne(nas);
            return nas;
        }

        public void UpdateNAS(string nasId, NASDto nas)
        {
            _nasCollection.ReplaceOne(n => n.NASId == nasId, nas);
        }

        public void DeleteNAS(string nasId)
        {
            _nasCollection.DeleteOne(nas => nas.NASId == nasId);
        }
    }
}