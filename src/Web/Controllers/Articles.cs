using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

public class Articles : ApiController
{
    [HttpGet]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<IResult> GetAll()
    {
        return await Task.FromResult(Results.Ok("Hello World"));
    }
}

