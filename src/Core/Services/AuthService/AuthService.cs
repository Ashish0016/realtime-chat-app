
using Core.Exceptions;
using Core.Feature.AccountFeature.UserLogin;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services.AuthService
{
    public class AuthService(IConfiguration configuration, UserManager<User> userManager) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly UserManager<User> _userManager = userManager;
        public async Task<string> GenerateJwtTokenAsync(UserLoginModel userLoginModel)
        {
            User user = await GeUserByCredential(userLoginModel);

            string key = _configuration.GetSection("JwtConfigurations:key").Get<string>() ?? string.Empty;
            IEnumerable<string> issuersList = configuration.GetSection("JwtConfigurations:Issuer").Get<IEnumerable<string>>() ?? Enumerable.Empty<string>();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Iss, "http://localhost:4200"),
            };

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: "http://localhost:4200",
                audience: "http://localhost:4200",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

        private async Task<User> GeUserByCredential(UserLoginModel userLoginModel)
        {
            User user = await _userManager.FindByEmailAsync(userLoginModel.Email) ?? new User();

            if (user is null)
            {
                throw new BadRequestException("Invalid email address.");
            }

            bool isValidPassword = await _userManager.CheckPasswordAsync(user, userLoginModel.Password);

            if (!isValidPassword)
            {
                throw new BadRequestException($"Invalid password.");
            }

            return user;
        }
    }
}
