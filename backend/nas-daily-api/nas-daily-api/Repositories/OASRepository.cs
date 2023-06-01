using System.Xml.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class OASRepository : IOASRepository
    {
        private readonly IMongoCollection<OAS> _oasCollection;

        public OASRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _oasCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<OAS>(options.Value.OASCollectionName);
        }

        public async Task<OAS> GetByUserId(string UserId)
        {
            return await _oasCollection.Find(oas => oas.OASId == UserId).FirstOrDefaultAsync();
        }
        public async Task<OAS> GetByName(string Name)
        {
            return await _oasCollection.Find(oas => oas.Name == Name).FirstOrDefaultAsync();
        }

        public async Task<string> DeleteByUserId(string UserId)
        {
            OAS user = await _oasCollection.Find(oas => oas.OASId == UserId).FirstOrDefaultAsync();
            if (user != null)
            {
                _oasCollection.DeleteOne(oas => oas.OASId == UserId);
                return UserId;
            }
            return "Failure";
        }


        public async Task<string> DeleteByName(string Name)
        {
            OAS user = await _oasCollection.Find(oas => oas.Name == Name).FirstOrDefaultAsync();
            if (user != null)
            {
                _oasCollection.DeleteOne(oas => oas.Name == Name);
                return Name;
            }
            return "Failure";
        }

        public async Task<OAS> Create(OAS oas)
        {
            await _oasCollection.InsertOneAsync(oas);
            return oas;

        }

        public async Task<OAS> Update(OAS oas, string userId)
        {
            var filter = Builders<OAS>.Filter.Eq("OASId", userId);
            await _oasCollection.ReplaceOneAsync(filter, oas);

            return oas;
        }

        public async Task<IEnumerable<OAS>> GetAllOAS()
        {
            return await _oasCollection.Find(_ => true).ToListAsync();
        }

    }
}
