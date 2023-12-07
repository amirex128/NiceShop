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
public class Categories : ApiController
{
    private readonly ISender _sender;

    public Categories(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CategoryDto>>> GetCategoriesWithPagination(
        [FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return await _sender.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
    {
        CategoryDto? actionResult = await _sender.Send(new GetCategoryByIdQuery(id));
        if (actionResult is null) return NotFound();
        return actionResult;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCategory(CreateCategoryCommand command)
    {
        return await _sender.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryCommand command)
    {
        if (id != command.Id) return BadRequest();
        await _sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _sender.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}
