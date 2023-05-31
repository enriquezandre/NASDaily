using Microsoft.Extensions.Options;
using MongoDB.Driver;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Dtos;
using nas_daily_api.Models;

namespace nas_daily_api.Repositories
{
    public class EvaluationResultRepository : IEvaluationResultRepository
    {
        private readonly IMongoCollection<EvaluationResult> _evaluationResultCollection;

        public EvaluationResultRepository(IOptions<DatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _evaluationResultCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<EvaluationResult>(options.Value.EvaluationResultCollectionName);
        }
        public async Task<EvaluationResult> Create(EvaluationResult evaluationResult)
        {
            await _evaluationResultCollection.InsertOneAsync(evaluationResult);
            return evaluationResult;
        }

        public async Task<string> DeleteByEvaluationId(string evaluationResultId)
        {
            EvaluationResult evaluationResult = await _evaluationResultCollection.Find(evaluationResult => evaluationResult.EvaluationResultId == evaluationResultId).FirstOrDefaultAsync();
            if (evaluationResult != null)
            {
                _evaluationResultCollection.DeleteOne(evaluationResult => evaluationResult.EvaluationResultId == evaluationResultId);
                return evaluationResultId;
            }
            return "Failure";
        }

        public async Task<IEnumerable<EvaluationResult>> GetAllEvaluationResult()
        {
            return await _evaluationResultCollection.Find(_ => true).ToListAsync();
        }

        public async Task<EvaluationResult> GetByEvaluationResultId(string EvaluationResultId)
        {
            return await _evaluationResultCollection.Find(EvaluationResult => EvaluationResult.EvaluationResultId == EvaluationResultId).FirstOrDefaultAsync();
        }

        public async Task<EvaluationResult> Update(EvaluationResult evaluationResult, string evaluationResultId)
        {
            var filter = Builders<EvaluationResult>.Filter.Eq("EvaluationResultId", evaluationResultId);
            await _evaluationResultCollection.ReplaceOneAsync(filter, evaluationResult);

            return evaluationResult;
        }
    }
}
