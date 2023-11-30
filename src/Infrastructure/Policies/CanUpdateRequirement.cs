using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Policies;

public class CanUpdateRequirement : IAuthorizationRequirement
{
}

public class CanUpdateRequirementHandler : AuthorizationHandler<CanUpdateRequirement, int>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _user;

    public CanUpdateRequirementHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> user)
    {
        _httpContextAccessor = httpContextAccessor;
        _user = user;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        CanUpdateRequirement requirement, int updatedModelUserId)
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
                    context.Fail();
                }
            }
        }

        context.Fail();
    }
}
