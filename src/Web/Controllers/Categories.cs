using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Categories.Commands.Create;
using NiceShop.Application.Features.Categories.Commands.Delete;
using NiceShop.Application.Features.Categories.Commands.Update;
using NiceShop.Application.Features.Categories.Queries.GetById;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class Categories(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<CategoryDto>>> GetAll(
        [FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
        return await mediator.Send(new GetCategoryByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<Result> Create([FromBody] CreateCategoryCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<Result> Update([FromBody] UpdateCategoryCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<Result> Delete(int id)
    {
        return await mediator.Send(new DeleteCategoryCommand(id));
    }
}
