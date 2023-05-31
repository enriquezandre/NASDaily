using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly IMongoCollection<AbsenceDto> _absenceCollection;

        public AbsenceRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _absenceCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<AbsenceDto>(options.Value.AbsenceCollectionName);
        }
        public AbsenceDto Create(AbsenceDto absence)
        {
            _absenceCollection.InsertOne(absence);
            return absence;
        }

        public string DeleteByAbsenceId(string absenceId)
        {
            AbsenceDto absence = _absenceCollection.Find(absence => absence.AbsenceId == absenceId).FirstOrDefault();
            if (absence != null)
            {
                _absenceCollection.DeleteOne(absence => absence.AbsenceId == absenceId);
                return absenceId;
            }
            return "Failure";
        }

        public List<AbsenceDto> GetAllAbsence()
        {
            return _absenceCollection.Find(_ => true).ToList();
        }

        public AbsenceDto GetByAbsenceId(string absenceId)
        {
            return _absenceCollection.Find(absence => absence.AbsenceId == absenceId).FirstOrDefault();
        }

        public AbsenceDto Update(AbsenceDto absence, string absenceId)
        {
            var filter = Builders<AbsenceDto>.Filter.Eq("AbsenceId", absenceId);
            _absenceCollection.ReplaceOne(filter, absence);

            return absence;
        }
    }
}
