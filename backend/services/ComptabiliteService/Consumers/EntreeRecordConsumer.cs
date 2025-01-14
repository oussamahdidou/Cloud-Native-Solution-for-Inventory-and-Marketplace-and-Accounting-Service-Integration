using ComptabiliteService.Entities;
using ComptabiliteService.Interfaces;
using ComptabiliteService.Mappers;
using EventsContracts.EventsContracts;
using MassTransit;

namespace ComptabiliteService.Consumers
{
    public class EntreeRecordConsumer : IConsumer<IEntreeRecordedEvent>
    {
        private readonly IEcritureComptableRepository ecritureComptableRepository;
        public EntreeRecordConsumer(IEcritureComptableRepository ecritureComptableRepository)
        {
            this.ecritureComptableRepository = ecritureComptableRepository;

        }
        public async Task Consume(ConsumeContext<IEntreeRecordedEvent> context)
        {
            EcritureComptable ecritureComptable = new EcritureComptable()
            {
                DateOperation = context.Message.Date,
                Libelle = "Achats de marchandises",
                Piece = $"Entree N°: {context.Message.Id}",
                Lignes = context.Message.FromEntreeToLigneEcriture()
            };
            await ecritureComptableRepository.AddEcritureComptable(ecritureComptable);
        }
    }
}
