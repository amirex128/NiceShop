using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.ProductAttributes.Commands.Create;
using NiceShop.Application.Features.ProductAttributes.Commands.Delete;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class ProductAttributesController(IMediator mediator) : ApiController
{
    [HttpGet()]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<Result>> Create([FromBody] CreateProductAttributeCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        var result = await mediator.Send(new DeleteProductAttributeCommand(id));
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }
}
