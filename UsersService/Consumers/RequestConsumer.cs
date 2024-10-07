using MassTransit;
using UsersService.Messages;

namespace UsersService.Consumers
{
    public class RequestConsumer : IConsumer<RequestMessage>
    {
        public async Task Consume(ConsumeContext<RequestMessage> context)
        {
            // Simulate processing
            var input = context.Message.Payload;
            await Console.Out.WriteLineAsync($"consumer received this : {input}");

            // Send back the response
            await context.RespondAsync(new ResponseMessage
            {
                Result = "Processed input: " + input
            });
        }
    }
}
