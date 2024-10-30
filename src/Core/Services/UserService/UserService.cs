using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Services.UserService
{
    public class UserService(UserManager<User> userManager, ChatAppContext context) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly ChatAppContext _context = context;
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
