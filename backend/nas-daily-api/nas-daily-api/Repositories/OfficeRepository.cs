using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IMongoCollection<OfficeDto> _officeCollection;

        public OfficeRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _officeCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<OfficeDto>(options.Value.OfficeCollectionName);
        }

        public OfficeDto GetByOfficeId(string officeId)
        {
            return _officeCollection.Find(office => office.OfficeId == officeId).FirstOrDefault();
        }

        public List<OfficeDto> GetAllOffices()
        {
            return _officeCollection.Find(_ => true).ToList();
        }

        public OfficeDto CreateOffice(OfficeDto office)
        {
            _officeCollection.InsertOne(office);
            return office;
        }

        public void UpdateOffice(string officeId, OfficeDto office)
        {
            _officeCollection.ReplaceOne(o => o.OfficeId == officeId, office);
        }

        public void DeleteOffice(string officeId)
        {
            _officeCollection.DeleteOne(office => office.OfficeId == officeId);
        }
    }
}
