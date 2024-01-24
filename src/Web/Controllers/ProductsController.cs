using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Products.Commands.Create;
using NiceShop.Application.Features.Products.Commands.Delete;
using NiceShop.Application.Features.Products.Commands.Update;
using NiceShop.Application.Features.Products.Queries.GetById;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class ProductsController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Pagination<ProductDto>>> GetAll([FromQuery] GetProductsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        return await mediator.Send(new GetProductByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Create([FromBody] CreateProductCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult<Result>> Update([FromBody] UpdateProductCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteProductCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
