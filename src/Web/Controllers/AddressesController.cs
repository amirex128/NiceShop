using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Addresses.Commands.Create;
using NiceShop.Application.Features.Addresses.Commands.Delete;
using NiceShop.Application.Features.Addresses.Commands.Update;
using NiceShop.Application.Features.Addresses.Queries.GetById;
using NiceShop.Application.Features.Addresses.Queries.GetCities;
using NiceShop.Application.Features.Addresses.Queries.GetProvinces;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;
using NiceShop.Domain.Constants;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class AddressesController(IMediator mediator) : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<Pagination<AddressDto>>> GetAll([FromQuery] GetAddressesWithPaginationQuery query)
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
    public async Task<ActionResult<Result>> Create([FromBody] CreateAddressCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult<Result>> Update([FromBody] UpdateAddressCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteAddressCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<List<City>>> GetCities([FromQuery] GetCitiesByNameQuery query)
    {
        return await mediator.Send(query);
    }

    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<List<Province>>> GetProvinces([FromQuery] GetProvincesByNameQuery query)
    {
        return await mediator.Send(query);
    }
}
