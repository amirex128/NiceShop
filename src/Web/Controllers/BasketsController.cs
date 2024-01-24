using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Baskets.Commands.Create;
using NiceShop.Application.Features.Baskets.Commands.Delete;
using NiceShop.Application.Features.Baskets.Commands.Update;
using NiceShop.Application.Features.Baskets.Queries.GetById;
using NiceShop.Application.Features.Baskets.Queries.GetWithPagination;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class BasketsController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<BasketDto>>> GetAll(
        [FromQuery] GetBasketsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<BasketDto>> Get(int id)
    {
        return await mediator.Send(new GetBasketByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Create([FromBody] CreateBasketCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult<Result>> Update([FromBody] UpdateBasketCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteBasketCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
