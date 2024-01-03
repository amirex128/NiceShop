using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Addresses.Commands.Create;
using NiceShop.Application.Features.Addresses.Commands.Delete;
using NiceShop.Application.Features.Addresses.Commands.Update;
using NiceShop.Application.Features.Addresses.Queries.GetById;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

public class Addresses(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<PaginatedList<AddressDto>>> GetAll([FromQuery] GetAddressesWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<AddressDto>> Get(int id)
    {
        return await mediator.Send(new GetAddressByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<Result> Create([FromBody] CreateAddressCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<Result> Update([FromBody] UpdateAddressCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<Result> Delete(int id)
    {
        return await mediator.Send(new DeleteAddressCommand(id));
    }
}
