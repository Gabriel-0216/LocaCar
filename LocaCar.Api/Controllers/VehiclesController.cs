using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.Requests;
using Domain.Queries.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-vehicles/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetVehiclesAsync([FromHeader] bool includeCategory,
            [FromHeader] bool includeFuelType, [FromHeader] bool includeRents, int skip = 0, int take = 25)
        {
            var query = new GetVehiclesQuery(includeCategory, includeFuelType, includeRents, skip, take);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("create-vehicle")]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] CreateVehicleRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}