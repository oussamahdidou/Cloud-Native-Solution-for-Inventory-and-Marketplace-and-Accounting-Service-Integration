namespace EventsContracts.EventsContracts
{
    public interface ICommandeItemEvent
    {
        string ItemId { set; get; }
        int Quantity { set; get; }
    }
}
