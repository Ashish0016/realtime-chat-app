using DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Feature.UserFeature.CreateUser
{
    public record CreateUserDto(string Email,
        string FirstName,
        string LastName,
        string Password,
        string ConfirmedPassword,
        string PhoneNumber) : IRequest<Unit>;
    public class CreateUserHandler : IRequestHandler<CreateUserDto, Unit>
    {
        private readonly UserManager<User> _userManager;
        public CreateUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            bool isUserExists = await _userManager
                .Users
                .AnyAsync(prop => prop.Email == request.Email, cancellationToken);

            if (!isUserExists)
            {

            }

            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = request.Password
            };

            throw new NotImplementedException();
        }
    }
}
