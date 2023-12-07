using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NiceShop.Domain.Constants;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Policies;

public class AdminCanCreateRequirementHandler : AuthorizationHandler<CanCreateRequirement>
{
    public AdminCanCreateRequirementHandler()
    {
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        CanCreateRequirement requirement)
    {
        
        if (context.User.IsInRole(ACL.Administrator))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}
