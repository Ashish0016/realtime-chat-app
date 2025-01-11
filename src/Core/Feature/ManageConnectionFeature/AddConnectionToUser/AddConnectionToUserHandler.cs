using Core.Exceptions;
using Core.Services.UserService;
using DataAccess;
using DataAccess.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Feature.ManageConnectionFeature.AddConnectionToUser
{
    public sealed record AddConnectionToUserModel(IEnumerable<string> ConnectedToUserIds) : IRequest<Unit>;
    public class AddConnectionToUserHandler : IRequestHandler<AddConnectionToUserModel, Unit>
    {
        private readonly ChatAppContext _context;
        private readonly IUserService _userService;
        public AddConnectionToUserHandler(ChatAppContext context,
            IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<Unit> Handle(AddConnectionToUserModel request, CancellationToken cancellationToken)
        {
            string loggedInUserId = _userService.UserId;

            if (string.IsNullOrWhiteSpace(loggedInUserId))
            {
                throw new NotFoundException("An unexpected error occoured.");
            }

            List<string> missingUserIds = request.ConnectedToUserIds
                .Where(id => !_context.Users
                    .AsNoTracking()
                    .Select(user => user.Id)
                    .Contains(id))
                .ToList();

            if (missingUserIds is not null && missingUserIds.Any())
            {
                throw new BadRequestException("Invalid user selection");
            }

            List<string> alreadyConnectedUsers = await _context.ConnectedUser
                .AsNoTracking()
                .Where(prop => request.ConnectedToUserIds.Contains(prop.ConnectedToUserId)
                    && prop.UserId == loggedInUserId
                    && prop.ConnectedToUser != null)
                .Select(prop => prop.ConnectedToUserId)
                .ToListAsync(cancellationToken);

            List<ConnectedUser> usersToBeConnected = request.ConnectedToUserIds
                .Where(prop => !alreadyConnectedUsers.Contains(prop))
                .Select(prop => new ConnectedUser()
                {
                    UserId = loggedInUserId,
                    ConnectedToUserId = prop
                })
                .ToList();

            if (usersToBeConnected is not null)
            {
                await _context.ConnectedUser.AddRangeAsync(usersToBeConnected);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
