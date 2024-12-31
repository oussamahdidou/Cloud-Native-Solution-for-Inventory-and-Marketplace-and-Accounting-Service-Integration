using ComptabiliteService.Entities;

namespace ComptabiliteService.Interfaces
{
    public interface IEcritureComptableService
    {
        Task<EcritureComptable> CreateEcritureComptable(EcritureComptable ecritureComptable);
    }
}
