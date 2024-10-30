using Core.Feature.AccountFeature.UserLogin;

namespace Core.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> GenerateJwtTokenAsync(UserLoginModel userLoginModel);
    }
}
