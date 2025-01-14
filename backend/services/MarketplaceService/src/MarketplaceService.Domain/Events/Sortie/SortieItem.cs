using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.Sortie
{
    public class SortieItem : ISortieItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
