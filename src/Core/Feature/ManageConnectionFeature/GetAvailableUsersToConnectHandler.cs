using Core.Services.UserService;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Feature.ManageConnectionFeature
{
    public record GetAvailableUsersToConnectModel(string? UserName,
        int pageSize = 10,
        int PageNumber = 0) : IRequest<GetAvailableUserToConnectResult>;
    public record GetAvailableUserToConnectResult
    {
        public List<AvailableUsersToConnect> UserList { get; set; } = new();
        public int TotalCount { get; set; }
    }
    public record AvailableUsersToConnect
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
    public class GetAvailableUsersToConnectHandler : IRequestHandler<GetAvailableUsersToConnectModel, GetAvailableUserToConnectResult>
    {
        private readonly IUserService _userService;
        private readonly ChatAppContext _context;
        public GetAvailableUsersToConnectHandler(IUserService userService,
            ChatAppContext context)
        {
            _userService = userService;
            _context = context;
        }
        public async Task<GetAvailableUserToConnectResult> Handle(GetAvailableUsersToConnectModel request, CancellationToken cancellationToken)
        {
            string loggedInUserId = _userService.UserId;

            List<AvailableUsersToConnect> availableUsersToConnects = await _context.Users
                .AsNoTracking()
                .Where(prop => prop.Id != loggedInUserId
                    &&
                    (
                        string.IsNullOrWhiteSpace(request.UserName) ||
                        prop.FirstName.Contains(request.UserName) ||
                        prop.LastName.Contains(request.UserName)
                    ))
                .Select(prop => new AvailableUsersToConnect()
                {
                    UserId = prop.Id,
                    UserName = prop.FirstName + " " + prop.LastName
                })
                .Skip(request.pageSize * request.PageNumber)
                .Take(request.pageSize)
                .ToListAsync(cancellationToken);

            return new GetAvailableUserToConnectResult()
            {
                UserList = availableUsersToConnects,
                TotalCount = availableUsersToConnects.Count
            };
        }
    }
}
