using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersService.Dto;
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

        private readonly ITokenService tokenService;
        public AccountController(ITokenService tokenService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
      
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
    }
}
