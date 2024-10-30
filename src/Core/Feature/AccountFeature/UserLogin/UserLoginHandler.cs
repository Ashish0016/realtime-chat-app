using Core.Services.AuthService;
using MediatR;

namespace Core.Feature.AccountFeature.UserLogin
{
    public record UserLoginModel(string Email, string Password) : IRequest<UserLoginResult>;
    public record UserLoginResult(string jwtToken);
    public class UserLoginHandler(IAuthService authService) : IRequestHandler<UserLoginModel, UserLoginResult>
    {
        private readonly IAuthService _authService = authService;
        public async Task<UserLoginResult> Handle(UserLoginModel request, CancellationToken cancellationToken)
        {
            string token = await _authService.GenerateJwtTokenAsync(request);

            return new UserLoginResult(jwtToken: token);
        }
    }
}
