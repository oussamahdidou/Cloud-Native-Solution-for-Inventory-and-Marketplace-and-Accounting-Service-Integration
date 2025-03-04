using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.Commande
{
    public class CommandeItemEvent : ICommandeItemEvent
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
