using ComptabiliteService.Entities;

namespace ComptabiliteService.Interfaces
{
    public interface IEcritureComptableRepository
    {
        Task<List<EcritureComptable>> GetAllEcrituresComptable();
        Task<EcritureComptable> GetEcritureComptableById(string Id);
        Task AddEcritureComptable(EcritureComptable ecritureComptable);
        Task DeleteEcritureComptable(string id);
        Task UpdateEcritureComptable(string Id, EcritureComptable ecritureComptable);
    }
}
