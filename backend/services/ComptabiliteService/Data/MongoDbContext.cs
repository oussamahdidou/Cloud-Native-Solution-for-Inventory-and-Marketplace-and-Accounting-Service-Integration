using ComptabiliteService.Entities;
using ComptabiliteService.Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ComptabiliteService.Data
{
    public class MongoDbContext
    {
        private IMongoDatabase _database;

        public MongoDbContext(IOptions<DatabaseSettings> settings, IMongoClient _client)
        {
            _database = _client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<EcritureComptable> EcritureComptables => _database.GetCollection<EcritureComptable>("EcritureComptables");

    }
}
