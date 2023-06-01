using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class EvaluationRatingRepository : IEvaluationRatingRepository
    {
        private readonly IMongoCollection<EvaluationRating> _evaluationRatingCollection;

        public EvaluationRatingRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _evaluationRatingCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<EvaluationRating>(options.Value.EvaluationRatingCollectionName);
        }
        public async Task<EvaluationRating> Create(EvaluationRating EvaluationRating)
        {
            await _evaluationRatingCollection.InsertOneAsync(EvaluationRating);
            return EvaluationRating;
        }

        public async Task<string> DeleteByEvaluationRatingId(string evaluationRatingId)
        {
            EvaluationRating evaluationRating = await _evaluationRatingCollection.Find(e => e.EvaluationRatingId == evaluationRatingId).FirstOrDefaultAsync();
            if (evaluationRating != null)
            {
                await _evaluationRatingCollection.DeleteOneAsync(e => e.EvaluationRatingId == evaluationRatingId);
                return evaluationRatingId;
            }
            return "Failure";
        }

        public async Task<IEnumerable<EvaluationRating>> GetAllEvaluationRating()
        {
            return await _evaluationRatingCollection.Find(_ => true).ToListAsync();
        }

        public async Task<EvaluationRating> GetByEvaluationRatingId(string evaluationRatingId)
        {
            return await _evaluationRatingCollection.Find(e => e.EvaluationRatingId == evaluationRatingId).FirstOrDefaultAsync();
        }

        public async Task<EvaluationRating> Update(EvaluationRating evaluationRating, string evaluationRatingId)
        {
            var filter = Builders<EvaluationRating>.Filter.Eq("EvaluationRatingId", evaluationRatingId);
            await _evaluationRatingCollection.ReplaceOneAsync(filter, evaluationRating);

            return evaluationRating;
        }
    }
}
