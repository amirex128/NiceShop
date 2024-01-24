using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Constants;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;
using NiceShop.Domain.Events;

namespace NiceShop.Application.Features.Users.Commands.Login;

public record LoginRegisterUserCommand : IRequest<Result>
{
    public string Phone { get; set; } = "";
}

public class LoginRegisterUserCommandValidator : AbstractValidator<LoginRegisterUserCommand>
{
    public LoginRegisterUserCommandValidator()
    {
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
    }
}

public class LoginRegisterUserCommandHandler(IApplicationDbContext context,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
    : IRequestHandler<LoginRegisterUserCommand, Result>
{
    public async Task<Result> Handle(LoginRegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(x => x.Otp)
            .SingleOrDefaultAsync(x => x.UserName == request.Phone || x.PhoneNumber == request.Phone,
                cancellationToken: cancellationToken);

        if (user is null)
        {
            user = new User()
            {
                UserName = request.Phone, PhoneNumber = request.Phone, IsActive = StatusEnum.Active, IsAdmin = false
            };
            user.Otp = new Otp { Code = new Random().Next(1000, 9999) };
            await context.Users.AddAsync(user, cancellationToken);
        }
        else
        {
            if (user.Otp is null)
            {
                user.Otp = new Otp { Code = new Random().Next(1000, 9999) };
            }

            if (user.Otp.IsUsed)
            {
                user.Otp.Code = new Random().Next(1000, 9999);
            }
            user.Otp.IsUsed = false;

        }

        user.AddDomainEvent(new SendOtpEvent(user.PhoneNumber, user.Email, user.Otp.Code));
        
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
            await roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanCreate));
            await roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanUpdate));
            await roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanDelete));
            await roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanGet));
            await roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanGetAll));
        }
        if (!string.IsNullOrWhiteSpace(administratorRole.Name))
        {
            await userManager.AddToRolesAsync(user, new[] { administratorRole.Name });
        }
        
        await context.SaveChangesAsync(cancellationToken);

        return Result.OperationSuccess();
    }
}
