using Core.Services.UserService;
using MediatR;

namespace Core.Feature.UserFeature.GetUsers
{
    public record GetLoggedInUserModel() : IRequest<GetLoggedInUserResult>;
    public record GetLoggedInUserResult(string UserId, string UserName, string Email);
    public class GetLoggedInUserHandler(IUserService userService) : IRequestHandler<GetLoggedInUserModel, GetLoggedInUserResult>
    {
        private readonly IUserService _userService = userService;
        public Task<GetLoggedInUserResult> Handle(GetLoggedInUserModel model, CancellationToken cancellationToken)
        {
            GetLoggedInUserResult loggedInUserResult = new GetLoggedInUserResult(_userService.UserId,
                _userService.UserName,
                _userService.Email);

            return Task.FromResult(loggedInUserResult);
        }
    }
}
