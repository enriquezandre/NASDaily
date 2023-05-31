using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class EvaluationResultRepository : IEvaluationResultRepository
    {
        private readonly IMongoCollection<EvaluationResultDto> _evaluationResultCollection;

        public EvaluationResultRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _evaluationResultCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<EvaluationResultDto>(options.Value.EvaluationResultCollectionName);
        }
        public EvaluationResultDto Create(EvaluationResultDto evaluationResult)
        {
            _evaluationResultCollection.InsertOne(evaluationResult);
            return evaluationResult;
        }

        public string DeleteByEvaluationId(string evaluationResultId)
        {
            EvaluationResultDto evaluationResult = _evaluationResultCollection.Find(evaluationResult => evaluationResult.EvaluationResultId == evaluationResultId).FirstOrDefault();
            if (evaluationResult != null)
            {
                _evaluationResultCollection.DeleteOne(evaluationResult => evaluationResult.EvaluationResultId == evaluationResultId);
                return evaluationResultId;
            }
            return "Failure";
        }

        public List<EvaluationResultDto> GetAllEvaluationResult()
        {
            return _evaluationResultCollection.Find(_ => true).ToList();
        }

        public EvaluationResultDto GetByEvaluationResultId(string EvaluationResultId)
        {
            return _evaluationResultCollection.Find(EvaluationResult => EvaluationResult.EvaluationResultId == EvaluationResultId).FirstOrDefault();
        }

        public EvaluationResultDto Update(EvaluationResultDto evaluationResult, string evaluationResultId)
        {
            var filter = Builders<EvaluationResultDto>.Filter.Eq("EvaluationResultId", evaluationResultId);
            _evaluationResultCollection.ReplaceOne(filter, evaluationResult);

            return evaluationResult;
        }
    }
}
