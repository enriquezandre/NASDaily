using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly IMongoCollection<Absence> _absenceCollection;

        public AbsenceRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _absenceCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Absence>(options.Value.AbsenceCollectionName);
        }
        public async Task<Absence> Create(Absence absence)
        {
            await _absenceCollection.InsertOneAsync(absence);
            return absence;
        }

        public async Task<string> DeleteByAbsenceId(string absenceId)
        {
            Absence absence = await _absenceCollection.Find(absence => absence.AbsenceId == absenceId).FirstOrDefaultAsync();
            if (absence != null)
            {
                _absenceCollection.DeleteOne(absence => absence.AbsenceId == absenceId);
                return absenceId;
            }
            return "Failure";
        }

        public async Task<IEnumerable<Absence>> GetAllAbsence()
        {
            return await _absenceCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Absence> GetByAbsenceId(string absenceId)
        {
            return await _absenceCollection.Find(absence => absence.AbsenceId == absenceId).FirstOrDefaultAsync();
        }

        public async Task<Absence> Update(Absence absence, string absenceId)
        {
            var filter = Builders<Absence>.Filter.Eq("AbsenceId", absenceId);
            await _absenceCollection.ReplaceOneAsync(filter, absence);

            return absence;
        }
    }
}
