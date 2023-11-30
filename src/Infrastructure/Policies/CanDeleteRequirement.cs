using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Policies;

public class CanDeleteRequirement : IAuthorizationRequirement
{
}

public class CanDeleteRequirementHandler : AuthorizationHandler<CanDeleteRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _user;

    public CanDeleteRequirementHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> user)
    {
        _httpContextAccessor = httpContextAccessor;
        _user = user;
    }

    protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context,
        CanDeleteRequirement requirement)
    {
        var httpContextUser = _httpContextAccessor.HttpContext?.User;
        if (httpContextUser is not null)
        {
            var findFirstValue = httpContextUser.FindFirstValue(ClaimTypes.NameIdentifier);
            if (findFirstValue is not null)
            {
                var user = await _user.FindByIdAsync(findFirstValue);
                if (user is not null)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
        }

        return Task.CompletedTask;
    }
}
