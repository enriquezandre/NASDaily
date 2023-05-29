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
        public OASDto GetByName(string Name)
        {
            return _oasCollection.Find(oas => oas.Name == Name).FirstOrDefault();
        }

        public string DeleteByUserId(string UserId)
        {
            OASDto user = _oasCollection.Find(oas => oas.UserId == UserId).FirstOrDefault();
            if (user != null)
            {
                _oasCollection.DeleteOne(oas => oas.UserId == UserId);
                return UserId;
            }
            return "Failure";
        }


        public string DeleteByName(string Name)
        {
            OASDto user = _oasCollection.Find(oas => oas.Name == Name).FirstOrDefault();
            if (user != null)
            {
                _oasCollection.DeleteOne(oas => oas.Name == Name);
                return Name;
            }
            return "Failure";
        }

        public OASDto Create(OASDto oas)
        {
            _oasCollection.InsertOne(oas);
            return oas;

        }

        public OASDto Update(OASDto oas, string userId)
        {
            var filter = Builders<OASDto>.Filter.Eq("UserId", userId);
            _oasCollection.ReplaceOne(filter, oas);

            return oas;
        }

        // Add more methods as per your requirements
    }
}
