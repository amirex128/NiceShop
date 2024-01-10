using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Medias.Commands.Create;
using NiceShop.Application.Features.Medias.Commands.Delete;
using NiceShop.Application.Features.Medias.Commands.Update;
using NiceShop.Application.Features.Medias.Queries.GetById;
using NiceShop.Application.Features.Medias.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class Medias(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<MediaDto>>> GetAll(
        [FromQuery] GetMediasWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<MediaDto?>> Get(int id)
    {
        return await mediator.Send(new GetMediaByIdQuery(id));
    }

    [HttpPut("{id}")]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<Result> UpdateCategory([FromBody] UpdateMediaCommand command)
    {
        return await mediator.Send(command);
    }


    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<Result> Create(CreateMediaCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<Result> Delete(int id)
    {
        return await mediator.Send(new DeleteMediaCommand(id));
    }
}
