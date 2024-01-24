using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Coupons.Commands.Check;
using NiceShop.Application.Features.Coupons.Commands.Create;
using NiceShop.Application.Features.Coupons.Commands.Delete;
using NiceShop.Application.Features.Coupons.Commands.Update;
using NiceShop.Application.Features.Coupons.Queries.GetById;
using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class CouponsController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<CouponDto>>> GetAll([FromQuery] GetCouponsWithPaginationQuery query)
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
    public async Task<ActionResult<Result>> Create([FromBody] CreateCouponCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult<Result>> Update([FromBody] UpdateCouponCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteCouponCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<Result>> Check([FromBody] CheckCouponCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
