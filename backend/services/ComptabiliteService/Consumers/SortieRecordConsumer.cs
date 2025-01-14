using ComptabiliteService.Entities;
using ComptabiliteService.Interfaces;
using ComptabiliteService.Mappers;
using EventsContracts.EventsContracts;
using MassTransit;

namespace ComptabiliteService.Consumers
{
    public class SortieRecordConsumer : IConsumer<ISortieRecordedEvent>
    {
        private readonly IEcritureComptableRepository ecritureComptableRepository;
        public SortieRecordConsumer(IEcritureComptableRepository ecritureComptableRepository)
        {
            this.ecritureComptableRepository = ecritureComptableRepository;
        }
        public async Task Consume(ConsumeContext<ISortieRecordedEvent> context)
        {
            EcritureComptable ecritureComptable = new EcritureComptable()
            {
                DateOperation = context.Message.Date,
                Libelle = "Ventes de marchandises",
                Piece = $"Sortie du stock le {context.Message.Date}",
                Lignes = context.Message.SortieItems.FromSortieItemToLigneEcriture()
            };
            await ecritureComptableRepository.AddEcritureComptable(ecritureComptable);
        }
    }
}
