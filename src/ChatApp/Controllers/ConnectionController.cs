using Core.Feature.ManageConnectionFeature;
using Core.Feature.ManageConnectionFeature.AddConnectionToUser;
using Core.Feature.ManageConnectionFeature.GetAllConnectedUsersToChat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConnectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("getAvailableUsersToConnect")]
        public async Task<IActionResult> GetAvailableUsersToConnect(
            [FromBody] GetAvailableUsersToConnectModel model)
        {
            return Ok(await _mediator.Send(model));
        }
        [HttpPost("AddConnectionToUser")]
        public async Task<IActionResult> AddConnectionToUser(
            [FromBody] AddConnectionToUserModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("getAllConnectedUsersToChat")]
        public async Task<IActionResult> GetAllConnectedUsersToChat(
            [FromRoute] GetAllConnectedUsersToChatModel model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
