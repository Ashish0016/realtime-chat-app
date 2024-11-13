using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Feature.UserFeature.GetUsers
{
    public record GetUserModel() : IRequest<GetUserResult>;
    public record GetUserResult(string UserId, string UserName);
    public class GetUserHandler : IRequestHandler<GetUserModel, GetUserResult>
    {
        //private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public Task<GetUserResult> Handle(GetUserModel model, CancellationToken cancellationToken)
        {
            //ClaimsPrincipal? claimsPrincipal = _httpContextAccessor?.HttpContext?.User;

            //if (claimsPrincipal is not null)
            //{
            //    string userName = claimsPrincipal.Identity.Name;
            //    //string userId = claimsPrincipal.Identity;
            //}

            return null;
        }
    }
}
