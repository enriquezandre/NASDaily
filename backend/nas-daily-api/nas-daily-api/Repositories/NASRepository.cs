using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class NASRepository : INASRepository
    {
        private readonly IMongoCollection<NAS> _nasCollection;

        public NASRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _nasCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<NAS>(options.Value.NASCollectionName);
        }

        public async Task<NAS> GetByNASId(string nasId)
        {
            return await _nasCollection.Find(nas => nas.NASId == nasId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NAS>> GetAllNAS()
        {
            return await _nasCollection.Find(_ => true).ToListAsync();
        }

        public async Task<NAS> CreateNAS(NAS nas)
        {
            await _nasCollection.InsertOneAsync(nas);
            return nas;
        }

        public async Task UpdateNAS(string nasId, NAS nas)
        {
            await _nasCollection.ReplaceOneAsync(n => n.NASId == nasId, nas);
        }

        public async Task DeleteNAS(string nasId)
        {
            await _nasCollection.DeleteOneAsync(nas => nas.NASId == nasId);
        }
    }
}