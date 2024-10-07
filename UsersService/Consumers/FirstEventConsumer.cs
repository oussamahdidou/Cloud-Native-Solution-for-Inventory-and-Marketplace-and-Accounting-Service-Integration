using MassTransit;
using UsersService.Messages;

namespace UsersService.Consumers
{
    public class FirstEventConsumer : IConsumer<MyEvent>
    {
        public Task Consume(ConsumeContext<MyEvent> context)
        {
            Console.WriteLine($"Queue One received: {context.Message.Value}");
            return Task.CompletedTask;
        }
    }
}
