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

public class Coupons(IMediator mediator) : ApiController
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
    public async Task<Result> Create([FromBody] CreateCouponCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<Result> Update([FromBody] UpdateCouponCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<Result> Delete(int id)
    {
        return await mediator.Send(new DeleteCouponCommand(id));
    }
    
    [HttpPost]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<Result> Check([FromBody] CheckCouponCommand command)
    {
        return await mediator.Send(command);
    }
}
