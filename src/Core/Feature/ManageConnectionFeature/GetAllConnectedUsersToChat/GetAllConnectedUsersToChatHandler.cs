using Core.Services.UserService;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Feature.ManageConnectionFeature.GetAllConnectedUsersToChat
{
    public sealed record GetAllConnectedUsersToChatModel : IRequest<List<GetAllConnectedUsersToChatResult>>;
    public sealed record GetAllConnectedUsersToChatResult(string UserId, string Name);
    public class GetAllConnectedUsersToChatHandler : IRequestHandler<GetAllConnectedUsersToChatModel, List<GetAllConnectedUsersToChatResult>>
    {
        private readonly ChatAppContext _context;
        private readonly IUserService _userService;
        public GetAllConnectedUsersToChatHandler(ChatAppContext context,
            IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<List<GetAllConnectedUsersToChatResult>> Handle(GetAllConnectedUsersToChatModel request, CancellationToken cancellationToken)
        {
            string loggedInUserId = _userService.UserId;

            List<GetAllConnectedUsersToChatResult> connectedUsers = await _context.ConnectedUser
                .Where(prop => prop.UserId == loggedInUserId)
                .Select(prop => new GetAllConnectedUsersToChatResult(prop.ConnectedToUser.Id, prop.ConnectedToUser.FirstName + " " + prop.ConnectedToUser.LastName))
                .ToListAsync();

            return connectedUsers;
        }
    }
}
