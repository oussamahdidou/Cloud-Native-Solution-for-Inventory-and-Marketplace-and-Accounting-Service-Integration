using Confluent.Kafka;
using EventsContracts.EventsContracts;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersService.Dto;
using UsersService.Events;
using UsersService.Interfaces;
using UsersService.Model;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IBus bus;
        private readonly ITokenService tokenService;
        public AccountController(ITokenService tokenService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBus bus)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.bus = bus;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);
            if (user == null)
                return NotFound("invalid username");
            var userconnected = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!userconnected.Succeeded)
                return NotFound("invalid password");
            string token = await tokenService.CreateToken(user);

            return Ok(new NewUserDto()
            {
                Username = user.UserName,
                Email = user.Email,
                Token = token
            });
        }
         [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDto model)
        {
            try
            {
                var appUser = new AppUser()
                {
                    UserName = model.Username,
                    Email = model.EmailAddress,

                };
                var createuser = await userManager.CreateAsync(appUser, model.Password);
                if (createuser.Succeeded)
                {
                    var roleresult = await userManager.AddToRoleAsync(appUser, "Customer");
                    if (roleresult.Succeeded)
                    {
                        NewUserRegistredEvent userRegistredEvent = new NewUserRegistredEvent()
                        {
                            CustomerId = appUser.Id,
                            UserName=appUser.UserName
                        };
                
                        await bus.Publish<INewUserRegistredEvent>(userRegistredEvent);

                        return Ok(new NewUserDto()
                        {
                            Username = appUser.UserName,
                            Email = appUser.Email,
                            Token = await tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleresult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createuser.Errors);

                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }

        }
    }
}
