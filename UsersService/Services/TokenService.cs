using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersService.Interfaces;
using UsersService.Model;

namespace UsersService.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey symmetricSecurityKey;
        private readonly UserManager<AppUser> userManager;
        public TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigninKey"]));
        }
        public async Task<string> CreateToken(AppUser appUser)
        {
            var roles = await userManager.GetRolesAsync(appUser);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,appUser.Email ),
                new Claim(JwtRegisteredClaimNames.Sub,appUser.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName,appUser.Id),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"]
            };

            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokenDescriptor);


            return tokenhandler.WriteToken(token);
        }
    }
}
