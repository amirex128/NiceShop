using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Addresses.Commands.Create;
using NiceShop.Application.Features.Addresses.Commands.Delete;
using NiceShop.Application.Features.Addresses.Commands.Update;
using NiceShop.Application.Features.Addresses.Queries.GetById;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

namespace NiceShop.Web.Controllers;

public class Addresses(IMediator mediator):ApiController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<AddressDto>>> Get([FromQuery] GetAddressesWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDto>> Get(int id)
    {
        return await mediator.Send(new GetAddressByIdQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateAddressCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult>Update([FromBody]UpdateAddressCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteAddressCommand(id));
        return NoContent();
    }
}
