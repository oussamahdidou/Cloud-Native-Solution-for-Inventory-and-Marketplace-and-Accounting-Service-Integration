using ComptabiliteService.Dtos;

namespace ComptabiliteService.Interfaces
{
    public interface IEcritureComptableService
    {
        Task CreateEcritureComptable(EcritureComptableDto ecritureComptableDto);
    }
}
