using Core.Feature.AccountFeature.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] UserLoginModel model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
