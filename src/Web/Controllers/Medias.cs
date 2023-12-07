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

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class Medias : ApiController
{
    private readonly ISender _sender;

    public Medias(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<MediaDto>>> GetMediasWithPagination(
        [FromQuery] GetMediasWithPaginationQuery query)
    {
        return await _sender.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MediaDto>> GetMediaById(int id)
    {
        MediaDto? actionResult = await _sender.Send(new GetMediaByIdQuery(id));
        if (actionResult is null) return NotFound();
        return actionResult;
    }

    [HttpPut("{id}")]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<IActionResult> UpdateCategory(int id, UpdateMediaCommand command)
    {
        if (id != command.Id) return BadRequest();
        await _sender.Send(command);
        return NoContent();
    }

    
    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<int>> CreateMedia(CreateMediaCommand command)
    {
        return await _sender.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedia(int id)
    {
        await _sender.Send(new DeleteMediaCommand(id));
        return NoContent();
    }
}
