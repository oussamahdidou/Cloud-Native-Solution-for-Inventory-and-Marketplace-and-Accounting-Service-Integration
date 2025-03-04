using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.ProductEvents
{
    public class ProductDeleteEvent : IProductDeleteEvent
    {
        public string Id { get; set; }
    }
}
