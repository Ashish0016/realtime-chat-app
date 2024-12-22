
namespace Core.Services.UserService
{
    public interface IUserService
    {
        public string UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        Task CreateUserAsync(CreateUserModel user, CancellationToken cancellationToken);
    }
    public record CreateUserModel(string Email,
        string FirstName,
        string LastName,
        string Password,
        string PhoneNumber);
}
