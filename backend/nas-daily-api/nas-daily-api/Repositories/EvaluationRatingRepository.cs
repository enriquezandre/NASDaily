using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class EvaluationRatingRepository : IEvaluationRatingRepository
    {
        private readonly IMongoCollection<EvaluationRatingDto> _evaluationRatingCollection;

        public EvaluationRatingRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _evaluationRatingCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<EvaluationRatingDto>(options.Value.EvaluationRatingCollectionName);
        }
        public EvaluationRatingDto Create(EvaluationRatingDto EvaluationRating)
        {
            _evaluationRatingCollection.InsertOne(EvaluationRating);
            return EvaluationRating;
        }

        public string DeleteByEvaluationRatingId(string EvaluationRatingId)
        {
            EvaluationRatingDto EvaluationRating = _evaluationRatingCollection.Find(EvaluationRating => EvaluationRating.EvaluationRatingId == EvaluationRatingId).FirstOrDefault();
            if (EvaluationRating != null)
            {
                _evaluationRatingCollection.DeleteOne(EvaluationRating => EvaluationRating.EvaluationRatingId == EvaluationRatingId);
                return EvaluationRatingId;
            }
            return "Failure";
        }

        public List<EvaluationRatingDto> GetAllEvaluationRating()
        {
            return _evaluationRatingCollection.Find(_ => true).ToList();
        }

        public EvaluationRatingDto GetByEvaluationRatingId(string EvaluationRatingId)
        {
            return _evaluationRatingCollection.Find(EvaluationRating => EvaluationRating.EvaluationRatingId == EvaluationRatingId).FirstOrDefault();
        }

        public EvaluationRatingDto Update(EvaluationRatingDto EvaluationRating, string evaluationRatingId)
        {
            var filter = Builders<EvaluationRatingDto>.Filter.Eq("EvaluationRatingId", evaluationRatingId);
            _evaluationRatingCollection.ReplaceOne(filter, EvaluationRating);

            return EvaluationRating;
        }
    }
}
