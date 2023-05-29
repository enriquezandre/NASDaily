using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public class OASRepository : IOASRepository
    {
        private readonly IMongoCollection<OASDto> _oasCollection;

        public OASRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _oasCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<OASDto>(options.Value.OASCollectionName);
        }

        public OASDto GetByUserId(string UserId)
        {
            return _oasCollection.Find(oas => oas.UserId == UserId).FirstOrDefault();
        }

        // Add more methods as per your requirements
    }
}
