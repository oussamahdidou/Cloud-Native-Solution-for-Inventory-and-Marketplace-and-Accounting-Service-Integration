namespace EventsContracts.EventsContracts
{
    public interface ISortieItem
    {
        string ProductId { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
    }
}
