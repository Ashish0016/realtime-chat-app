using AutoMapper;
using Core.Exceptions;
using Core.Feature.AccountFeature.UserLogin;
using Core.Services.AuthService;
using Core.Services.UserService;
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
        string ConfirmPassword,
        string PhoneNumber) : IRequest<UserLoginResult>;
    public class CreateUserHandler(UserManager<User> userManager,
        IUserService userService,
        IMapper mapper,
        IAuthService authService) : IRequestHandler<CreateUserDto, UserLoginResult>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;
        private readonly IAuthService _authService = authService;
        public async Task<UserLoginResult> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            bool isUserExists = await _userManager
                .Users
                .AnyAsync(prop => prop.Email == request.Email, cancellationToken);

            if (isUserExists)
            {
                throw new BadRequestException("User with the provided email already exists.");
            }

            CreateUserModel model = _mapper.Map<CreateUserModel>(request);
            await _userService.CreateUserAsync(model, cancellationToken);

            UserLoginModel userLogin = new UserLoginModel(model.Email, model.Password);
            string token = await _authService.GenerateJwtTokenAsync(userLogin);

            return new UserLoginResult(jwtToken: token);
        }
    }
}
