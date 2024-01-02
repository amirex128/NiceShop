using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Products.Commands.Create;
using NiceShop.Application.Features.Products.Commands.Delete;
using NiceShop.Application.Features.Products.Commands.Update;
using NiceShop.Application.Features.Products.Queries.GetById;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Web.Controllers;

public class Products(IMediator mediator) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProductDto>>> Get([FromQuery] GetProductsWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        return await mediator.Send(new GetProductByIdQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateProductCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}
