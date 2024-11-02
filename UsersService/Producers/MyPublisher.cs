using MassTransit;
using UsersService.Events;

namespace UsersService.Producers
{
    public class MyPublisher
    {
        private readonly IBus _bus;

        public MyPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishToCustomExchange(string value)
        {
            var message = new MyEvent { Value = value };

            // Specify the custom exchange
            var sendEndpoint = await _bus.GetSendEndpoint(new Uri("exchange:publish_exchange"));

            // Publish the message to the custom exchange
            await sendEndpoint.Send(message);
        }
    }
}
