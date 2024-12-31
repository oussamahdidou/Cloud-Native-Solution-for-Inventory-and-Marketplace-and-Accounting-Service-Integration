using ComptabiliteService.Entities;
using MongoDB.Bson;

namespace ComptabiliteService.Interfaces
{
    public interface IEcritureComptableRepository
    {
        Task<List<EcritureComptable>> GetAllEcrituresComptable();
        Task<EcritureComptable> GetEcritureComptableById(ObjectId Id);
        Task AddEcritureComptable(EcritureComptable ecritureComptable);
        Task DeleteEcritureComptable(ObjectId id);
        Task UpdateEcritureComptable(ObjectId Id, EcritureComptable ecritureComptable);
    }
}
