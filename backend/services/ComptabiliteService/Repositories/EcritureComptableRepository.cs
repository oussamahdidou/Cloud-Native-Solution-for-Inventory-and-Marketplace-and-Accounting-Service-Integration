using ComptabiliteService.Entities;
using ComptabiliteService.Interfaces;
using MongoDB.Driver;

namespace ComptabiliteService.Repositories
{
    public class EcritureComptableRepository : IEcritureComptableRepository
    {
        private readonly IMongoCollection<EcritureComptable> ecritureComptableCollection;
        public EcritureComptableRepository(IMongoDatabase database)
        {
            this.ecritureComptableCollection = database.GetCollection<EcritureComptable>("EcritureComptables");
        }
        public async Task AddEcritureComptable(EcritureComptable ecritureComptable)
        {
            await ecritureComptableCollection.InsertOneAsync(ecritureComptable).ConfigureAwait(false);
        }

        public async Task DeleteEcritureComptable(string id)
        {
            await ecritureComptableCollection.DeleteOneAsync(ec => ec.Id == id).ConfigureAwait(false);
        }

        public async Task<List<EcritureComptable>> GetAllEcrituresComptable()
        {
            return await ecritureComptableCollection.Find(ec => true).ToListAsync().ConfigureAwait(false);
        }

        public async Task<EcritureComptable> GetEcritureComptableById(string Id)
        {
            return await ecritureComptableCollection.Find(ec => ec.Id == Id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task UpdateEcritureComptable(string id, EcritureComptable ecritureComptable)
        {
            await ecritureComptableCollection.ReplaceOneAsync(ec => ec.Id == id, ecritureComptable).ConfigureAwait(false);
        }
    }
}
