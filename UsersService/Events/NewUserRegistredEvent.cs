using EventsContracts.EventsContracts;

namespace UsersService.Events
{
    public class NewUserRegistredEvent :INewUserRegistredEvent
    {
        public string CustomerId { get; set; }
        public string UserName { get; set; }
    }
}
