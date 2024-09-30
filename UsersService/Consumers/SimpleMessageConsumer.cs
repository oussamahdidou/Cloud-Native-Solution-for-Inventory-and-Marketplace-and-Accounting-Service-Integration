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
            Console.WriteLine(value: context.Message.Text);
            return Task.CompletedTask;
        }
    }
}