using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Coupons.Commands.Create;
using NiceShop.Application.Features.Coupons.Commands.Delete;
using NiceShop.Application.Features.Coupons.Commands.Update;
using NiceShop.Application.Features.Coupons.Queries.GetById;
using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

public class Coupons(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<PaginatedList<CouponDto>>> GetAll([FromQuery] GetCouponsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<CouponDto>> Get(int id)
    {
        return await mediator.Send(new GetCouponByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<int>> Create([FromBody] CreateCouponCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult>Update([FromBody]UpdateCouponCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCouponCommand(id));
        return NoContent();
    }
    
}
