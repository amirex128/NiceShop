using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Coupons.Commands.Create;
using NiceShop.Application.Features.Coupons.Commands.Delete;
using NiceShop.Application.Features.Coupons.Commands.Update;
using NiceShop.Application.Features.Coupons.Queries.GetById;
using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

namespace NiceShop.Web.Controllers;

public class Coupons(IMediator mediator) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CouponDto>>> Get([FromQuery] GetCouponsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CouponDto>> Get(int id)
    {
        return await mediator.Send(new GetCouponByIdQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCouponCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult>Update([FromBody]UpdateCouponCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCouponCommand(id));
        return NoContent();
    }
    
}
