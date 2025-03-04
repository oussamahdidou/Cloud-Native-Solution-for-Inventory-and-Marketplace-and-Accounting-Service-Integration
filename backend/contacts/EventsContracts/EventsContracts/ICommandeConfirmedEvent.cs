namespace EventsContracts.EventsContracts
{
    public interface ICommandeConfirmedEvent
    {
        List<ICommandeItemEvent> Items { set; get; }

        DateTime Date { set; get; }

    }
}
