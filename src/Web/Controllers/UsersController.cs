using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Users.Commands.ApproveOTP;
using NiceShop.Application.Features.Users.Commands.Login;

namespace NiceShop.Web.Controllers;

[ApiVersion("1.0")]
public class UsersController(IMediator mediator) : ApiController
{
    [HttpPost]
    public async Task<Result> LoginRegister(
        [FromBody] LoginRegisterUserCommand loginRegister)
    {
        return await mediator.Send(loginRegister);
    }

    [HttpPost]
    public async Task<Result> ApproveOtp(
        [FromBody] ApproveOtpUserCommand loginRegister)
    {
        return await mediator.Send(loginRegister);
    }
}
