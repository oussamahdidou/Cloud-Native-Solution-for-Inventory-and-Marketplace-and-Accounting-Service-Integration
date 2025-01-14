using EventsContracts.EventsContracts;

namespace ComptabiliteService.Events
{
    public class EntreeRecordedEvent : IEntreeRecordedEvent
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
