using Core.Feature.UserFeature.CreateUser;
using Core.Feature.UserFeature.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserDto model)
        {
            return Ok(await _mediator.Send(model));
        }
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers(
            [FromRoute] GetUserModel model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
