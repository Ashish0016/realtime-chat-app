using FluentValidation;

namespace Core.Feature.UserFeature.CreateUser
{
    public class CreateUserModelValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserModelValidator()
        {
            RuleFor(prop => prop.Email).NotEmpty();
            RuleFor(prop => prop.FirstName).NotEmpty();
            RuleFor(prop => prop.LastName).NotEmpty();
            RuleFor(prop => prop.Password).NotEmpty();
            RuleFor(prop => prop.ConfirmPassword).NotEmpty();
        }
    }
}
