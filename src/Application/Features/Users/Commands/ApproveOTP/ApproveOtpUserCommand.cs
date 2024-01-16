using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Users.Commands.ApproveOTP;

public record ApproveOtpUserCommand : IRequest<Result>
{
    public string Phone { get; set; } = "";
    public int Otp { get; set; }
}

public class ApproveOtpUserCommandValidator : AbstractValidator<ApproveOtpUserCommand>
{
    public ApproveOtpUserCommandValidator()
    {
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.Otp).NotEmpty().WithMessage("Otp is required")
            .GreaterThan(999).WithMessage("Otp is invalid");
    }
}

public class ApproveOtpUserCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    : IRequestHandler<ApproveOtpUserCommand, Result>
{
    public async Task<Result> Handle(ApproveOtpUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(x => x.Otp)
            .SingleOrDefaultAsync(x => x.UserName == request.Phone || x.PhoneNumber == request.Phone,
                cancellationToken: cancellationToken);
        Guard.Against.NotFound(request.Phone, user);

        if (user.Otp is null || user.Otp.IsUsed)
        {
            return Result.OperationFailed("کد فعال سازی برای شما ارسال نشده هنوز");
        }

        if (user.Otp.Code != request.Otp)
        {
            return Result.OperationFailed("کد فعال سازی اشتباه است");
        }

        user.Otp.IsUsed = true;
        await context.SaveChangesAsync(cancellationToken);

        var token = identityService.GenerateJwtToken(user);
        return Result.OperationSuccess(new { Token = token });

    }


}
