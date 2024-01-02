using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Categories.Commands.Create;
using NiceShop.Application.Features.Categories.Commands.Delete;
using NiceShop.Application.Features.Categories.Commands.Update;
using NiceShop.Application.Features.Categories.Queries.GetById;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class Categories(IMediator mediator) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CategoryDto>>> Get([FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
        return await mediator.Send(new GetCategoryByIdQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCategoryCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCategoryCommand(id));

        return NoContent();
    }
}
