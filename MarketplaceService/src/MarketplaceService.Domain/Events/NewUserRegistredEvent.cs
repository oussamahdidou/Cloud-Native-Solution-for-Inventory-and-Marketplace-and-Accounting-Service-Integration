using EventsContracts.EventsContracts;

namespace MarketplaceService.Domain.Events
{
    public class NewUserRegistredEvent:INewUserRegistredEvent
    {
        public string CustomerId { get; set; }
        public string UserName { get; set; }
    }
}
