using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Users.Commands.ApproveOTP;
using NiceShop.Application.Features.Users.Commands.Login;
using NiceShop.Application.Features.Users.Queries.Info;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class UsersController(IMediator mediator) : ApiController
{
    [HttpPost]
    public async Task<ActionResult<Result>> LoginRegister(
        [FromBody] LoginRegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> ApproveOtp(
        [FromBody] ApproveOtpUserCommand command)
    {
        var result = await mediator.Send(command);
        return result.Succeeded ? Ok(result) : StatusCode(400, result);
    }

    [HttpGet]
    public async Task<UserDto?> Info(
        [FromQuery] UserInfoQuery userInfoQuery)
    {
        return await mediator.Send(userInfoQuery);
    }
}
