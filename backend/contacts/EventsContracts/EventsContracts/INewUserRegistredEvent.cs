namespace EventsContracts.EventsContracts
{
    public interface INewUserRegistredEvent
    {
        string CustomerId { get; set; }
        string UserName { get; set; }
    }
}
