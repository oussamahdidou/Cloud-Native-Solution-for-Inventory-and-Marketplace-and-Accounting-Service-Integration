using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.Commande
{
    public class CommandeConfirmedEvent : ICommandeConfirmedEvent
    {
        public List<ICommandeItemEvent> Items { get; set; }
        public DateTime Date { get; set; }
    }
}
