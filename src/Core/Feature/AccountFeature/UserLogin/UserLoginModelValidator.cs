using FluentValidation;

namespace Core.Feature.AccountFeature.UserLogin
{
    public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginModelValidator()
        {
            RuleFor(prop => prop.Email)
                .NotEmpty()
                .Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

            RuleFor(prop => prop.Password)
                .NotEmpty()
                .Matches(@"^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$");
        }
    }
}
