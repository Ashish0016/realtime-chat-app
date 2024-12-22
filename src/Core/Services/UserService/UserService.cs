using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Services.UserService
{
    public class UserService(UserManager<User> userManager,
        ChatAppContext context,
        IHttpContextAccessor _httpContextAccessor) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly ChatAppContext _context = context;

        public string UserName => _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Name)?.Value ?? string.Empty;
        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? string.Empty;
        public string Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;

        public async Task CreateUserAsync(CreateUserModel userModel, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                UserName = userModel.Email,
                NormalizedUserName = userModel.Email.ToUpper(),
                Email = userModel.Email,
                NormalizedEmail = userModel.Email.ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = userModel.PhoneNumber
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user);

            if (identityResult.Succeeded)
            {
                await _userManager.AddPasswordAsync(user, userModel.Password);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return;
        }
    }
}
