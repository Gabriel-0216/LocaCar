using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("user-login")]
        public async Task<IActionResult> UserLoginAsync([FromBody] UserLoginRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("user-change-password")]
        public async Task<IActionResult> ChangePasswordAsync()
        {
            return BadRequest();
        }

        [HttpPost]
        [Route("user-change-email")]
        public async Task<IActionResult> ChangeEmailAsync()
        {
            return BadRequest();
        }
    }
}