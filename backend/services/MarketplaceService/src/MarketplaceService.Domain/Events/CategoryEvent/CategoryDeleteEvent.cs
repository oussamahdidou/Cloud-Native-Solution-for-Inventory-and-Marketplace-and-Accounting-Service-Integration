using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.CategoryEvent
{
    public class CategoryDeleteEvent : ICategoryDeleteEvent
    {
        public string CategoryId { get; set; }
    }
}
