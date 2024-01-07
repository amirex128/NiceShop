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

public class Products(IMediator mediator) : ApiController
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
    public async Task<Result> Create([FromBody] CreateProductCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<Result> Update([FromBody] UpdateProductCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<Result> Delete(int id)
    {
        return await mediator.Send(new DeleteProductCommand(id));
    }
}
