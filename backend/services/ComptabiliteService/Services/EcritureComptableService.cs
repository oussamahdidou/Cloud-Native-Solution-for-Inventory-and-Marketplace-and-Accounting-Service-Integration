using ComptabiliteService.Dtos;
using ComptabiliteService.Interfaces;
using ComptabiliteService.Mappers;

namespace ComptabiliteService.Services
{
    public class EcritureComptableService : IEcritureComptableService
    {
        private readonly IEcritureComptableRepository ecritureComptableRepository;
        public EcritureComptableService(IEcritureComptableRepository ecritureComptableRepository)
        {
            this.ecritureComptableRepository = ecritureComptableRepository;
        }
        public async Task CreateEcritureComptable(EcritureComptableDto ecritureComptableDto)
        {
            await ecritureComptableRepository.AddEcritureComptable(ecritureComptableDto.FromEcritureComptableDtoToEcritureComptable());
        }
    }
}
