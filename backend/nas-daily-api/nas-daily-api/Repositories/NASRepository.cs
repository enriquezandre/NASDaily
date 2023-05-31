using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nas_daily_api.Repositories
{
    public class NASRepository : INASRepository
    {
        private readonly IMongoCollection<NAS> _nasCollection;

        public NASRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _nasCollection = database.GetCollection<NAS>(options.Value.NASCollectionName);
        }

        public async Task<List<NAS>> GetAllNAS()
        {
            return await _nasCollection.Find(_ => true).ToListAsync();
        }

        public async Task<NAS> GetByNASId(string nasId)
        {
            return await _nasCollection.Find(nas => nas.NASId == nasId).FirstOrDefaultAsync();
        }

        public async Task<NAS> GetByUserName(string userName)
        {
            return await _nasCollection.Find(nas => nas.Username == userName).FirstOrDefaultAsync();
        }

        public async Task<NAS> CreateNAS(NAS nas)
        {
            nas.NASId = ObjectId.GenerateNewId().ToString();
            await _nasCollection.InsertOneAsync(nas);
            return nas;
        }

        public async Task UpdateNAS(string nasId, NAS nas)
        {
            var filter = Builders<NAS>.Filter.Eq(n => n.NASId, nasId);
            await _nasCollection.ReplaceOneAsync(filter, nas);
        }

        public async Task DeleteNAS(string nasId)
        {
            var filter = Builders<NAS>.Filter.Eq(nas => nas.NASId, nasId);
            await _nasCollection.DeleteOneAsync(filter);
        }
    }
}