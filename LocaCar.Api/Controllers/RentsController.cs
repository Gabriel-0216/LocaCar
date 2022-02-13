using Domain.Commands.Requests;
using Domain.Queries.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-rents/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetRentsAsync([FromHeader] bool includeClient,
            [FromHeader] bool includePayment, [FromHeader] bool includeVehicles,
            [FromRoute] int skip = 0, int take = 25)
        {
            var query = new GetRentsQuery(includeClient, includePayment, includeVehicles, skip, take);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("simulate-loan")]
        public async Task<IActionResult> SimulateLoanAsync([FromBody] SimulateRentRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("insert-rent")]
        public async Task<IActionResult> InsertRentAsync([FromBody] CreateRentRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}