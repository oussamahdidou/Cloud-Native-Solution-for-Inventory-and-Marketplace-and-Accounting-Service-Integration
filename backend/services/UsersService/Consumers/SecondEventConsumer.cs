﻿using MassTransit;
using UsersService.Events;

namespace UsersService.Consumers
{
    public class SecondEventConsumer : IConsumer<MyEvent>
    {
        public Task Consume(ConsumeContext<MyEvent> context)
        {
            Console.WriteLine($"Queue Two received: {context.Message.Value}");

            return Task.CompletedTask;
        }
    }
}
