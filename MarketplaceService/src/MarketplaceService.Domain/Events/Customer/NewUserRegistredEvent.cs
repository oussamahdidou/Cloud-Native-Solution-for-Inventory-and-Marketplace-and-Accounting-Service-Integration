using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events.Customer
{
    public class NewUserRegistredEvent : INewUserRegistredEvent
    {
        public string CustomerId { get; set; }
        public string UserName { get; set; }
    }
}
