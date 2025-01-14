namespace EventsContracts.EventsContracts
{
    public interface IEntreeRecordedEvent
    {
        string Id { get; set; }
        double Price { get; set; }
        int Quantity { get; set; }
        DateTime Date { get; set; }
    }
}
