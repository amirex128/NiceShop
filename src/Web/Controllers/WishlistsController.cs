using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;
using NiceShop.Application.Features.Wishlists.Commands.Create;
using NiceShop.Application.Features.Wishlists.Commands.Delete;
using NiceShop.Application.Features.Wishlists.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class WishlistsController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<ProductDto>>> GetAll([FromQuery] GetWishlistsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Create([FromBody] CreateWishlistCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }


    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteWishlistCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
