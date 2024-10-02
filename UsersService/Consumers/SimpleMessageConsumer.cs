using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace UsersService.Consumers
{
    public class SimpleMessageConsumer : IConsumer<SimpleMessage>
    {
        public Task Consume(ConsumeContext<SimpleMessage> context)
        {
            var message = context.Message;
            Console.WriteLine("message received " + message.Text);

            return Task.CompletedTask;
        }
    }
}