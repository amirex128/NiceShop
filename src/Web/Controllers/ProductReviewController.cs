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
    public async Task<Result> Create([FromBody] CreateProductReviewCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<Result> Delete(int id)
    {
        return await mediator.Send(new DeleteProductReviewCommand(id));
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<Result> Reaction([FromBody] ReactionProductReviewCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<Result> Approve([FromBody] ApproveProductReviewCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<Result> Update([FromBody] UpdateProductReviewCommand command)
    {
        return await mediator.Send(command);
    }
}
