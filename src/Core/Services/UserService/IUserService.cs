
namespace Core.Services.UserService
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserModel user, CancellationToken cancellationToken);
    }
    public record CreateUserModel(string Email,
        string FirstName,
        string LastName,
        string Password,
        string PhoneNumber);
}
