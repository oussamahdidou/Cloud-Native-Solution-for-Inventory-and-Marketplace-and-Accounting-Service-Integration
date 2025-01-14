using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.Sortie
{
    public class SortieRecordedEvent : ISortieRecordedEvent
    {
        public List<ISortieItem> SortieItems { get; set; } = new List<ISortieItem>();
        public DateTime Date { get; set; }
    }
}
