using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Orders.Commands.Create;
using NiceShop.Application.Features.Orders.Commands.Verify;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;
using NiceShop.Application.Features.Wishlists.Commands.Create;
using NiceShop.Application.Features.Wishlists.Commands.Delete;
using NiceShop.Application.Features.Wishlists.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class OrdersController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<ProductDto>>> GetAll([FromQuery] GetWishlistsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Create([FromBody] CreateOrderCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Verify([FromBody] VerifyOrderCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
