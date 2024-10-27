using AutoMapper;
using Core.Exceptions;
using Core.Services.UserService;
using DataAccess;
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
    public class CreateUserHandler(UserManager<User> userManager,
        IUserService userService,
        IMapper mapper) : IRequestHandler<CreateUserDto, Unit>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;
        public async Task<Unit> Handle(CreateUserDto request, CancellationToken cancellationToken)
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

            return Unit.Value;
        }
    }
}
