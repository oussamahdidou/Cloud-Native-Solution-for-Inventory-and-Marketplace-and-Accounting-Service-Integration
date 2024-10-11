using MassTransit;
using UsersService.Messages;

namespace UsersService.Producers
{
    public class MyRequester
    {
        private readonly IRequestClient<RequestMessage> _requestClient;

        public MyRequester(IRequestClient<RequestMessage> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task SendRequest(string value)
        {
            var request = new RequestMessage { Payload = value };
            var requestId = Guid.NewGuid();
            // Send the request and wait for the response
            var response = await _requestClient.GetResponse<ResponseMessage>(request);

            Console.WriteLine($"Response: {response.Message.Result}");
        }
    }

}
