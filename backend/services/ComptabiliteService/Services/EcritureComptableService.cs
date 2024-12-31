using ComptabiliteService.Entities;
using ComptabiliteService.Interfaces;

namespace ComptabiliteService.Services
{
    public class EcritureComptableService : IEcritureComptableService
    {
        private readonly IEcritureComptableRepository ecritureComptableRepository;
        public EcritureComptableService(IEcritureComptableRepository ecritureComptableRepository)
        {
            this.ecritureComptableRepository = ecritureComptableRepository;
        }
        public async Task<EcritureComptable> CreateEcritureComptable(EcritureComptable ecritureComptable)
        {
            await ecritureComptableRepository.AddEcritureComptable(ecritureComptable);
            return ecritureComptable;
        }
    }
}
