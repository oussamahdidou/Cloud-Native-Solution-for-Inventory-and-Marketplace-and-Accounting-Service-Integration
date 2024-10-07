using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersService.Messages;
using UsersService.Producers;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly MyRequester _myRequester;
        private readonly MyPublisher myPublisher;

        public DataController(MyRequester myRequester, MyPublisher myPublisher)
        {
            _myRequester = myRequester;
            this.myPublisher = myPublisher;
        }

        [HttpGet("send-request")]
        public async Task<IActionResult> SendRequest()
        {
            await _myRequester.SendRequest("Test Value");
            return Ok("Request Sent");
        }
        [HttpGet("publish-event")]
        public async Task<IActionResult> PublishEvent()
        {
            await myPublisher.PublishToCustomExchange("Test Value");
            return Ok("Request Sent");
        }
    }
}
