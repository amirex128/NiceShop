using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.ProductReviews.Commands.Approve;
using NiceShop.Application.Features.ProductReviews.Commands.Create;
using NiceShop.Application.Features.ProductReviews.Commands.Delete;
using NiceShop.Application.Features.ProductReviews.Commands.Reaction;
using NiceShop.Application.Features.ProductReviews.Commands.Update;
using NiceShop.Application.Features.ProductReviews.Queries.GetWithPagination;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class ProductReviewController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<ProductReviewDto>>> GetAll(
        [FromQuery] GetProductReviewsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Create([FromBody] CreateProductReviewCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteProductReviewCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Reaction([FromBody] ReactionProductReviewCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Approve([FromBody] ApproveProductReviewCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult<Result>> Update([FromBody] UpdateProductReviewCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
