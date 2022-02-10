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
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-categories/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetCategoriesAsync([FromHeader] bool includeVehicles, [FromRoute] int skip = 0,
            [FromRoute] int take = 25)
        {
            var command = new GetCategoriesQuery(includeVehicles, skip, take);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("update-category")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("delete-category")]
        public async Task<IActionResult> DeleteCategoryAsync([FromBody] DeleteCategoryRequest command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}