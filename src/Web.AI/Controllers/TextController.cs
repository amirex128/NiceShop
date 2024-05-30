using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Domain.Constants;
using NiceShop.Web.AI.Controllers;

namespace NiceShop.Web.AI.Controllers;

[ApiVersion("1.0")]
public class TextController() : ApiController
{
    [HttpGet("")]
    [Authorize(Policy = ACL.CanGet)]
    public  ActionResult Get()
    {
        return Ok();
    }

}
