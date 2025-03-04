using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.CategoryEvent
{
    internal class UpdateCategoryEvent : IUpdateCategoryEvent
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}
