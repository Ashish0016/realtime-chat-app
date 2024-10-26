using MediatR;

namespace Core.Feature.AccountFeature.UserLogin
{
    public record UserLoginModel(string Email, string Password) : IRequest<UserLoginResult>;
    public record UserLoginResult(int Id, string UserName);
    public class UserLoginHandler : IRequestHandler<UserLoginModel, UserLoginResult>
    {
        public Task<UserLoginResult> Handle(UserLoginModel request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return Task.FromResult(new UserLoginResult(0, string.Empty));
            }

            Random random = new Random();
            int randomNumber = random.Next(1, 10);

            string[] userName = request.Email.Split("@");

            UserLoginResult result = new UserLoginResult(randomNumber, userName[0]);

            return Task.FromResult(result);
        }
    }
}
