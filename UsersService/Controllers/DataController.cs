using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersService.Messages;
using UsersService.Model;
using UsersService.Producers;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly MyPublisher myPublisher;
        private readonly UserManager<AppUser> userManager;
        public DataController(MyPublisher myPublisher, UserManager<AppUser> userManager)
        {
            this.myPublisher = myPublisher;
            this.userManager = userManager;
        }

        [HttpGet("send-request/{username}")]
        public async Task<IActionResult> SendRequest([FromRoute] string username)
        {
      
            return Ok((await userManager.FindByNameAsync(username)).Id);
        }
        [HttpGet("publish-event")]
        public async Task<IActionResult> PublishEvent()
        {
            await myPublisher.PublishToCustomExchange("Test Value");
            return Ok("Request Sent");
        }
  
    }
}
