using Core.Feature.UserFeature.CreateUser;
using MediatR;
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
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserDto model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
