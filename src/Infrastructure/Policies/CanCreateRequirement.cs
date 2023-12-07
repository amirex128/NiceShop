using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Policies;

public class CanCreateRequirement : IAuthorizationRequirement
{
}

public class CanCreateRequirementHandler : AuthorizationHandler<CanCreateRequirement,int>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _user;
    private readonly RoleManager<IdentityRole> _role;

    public CanCreateRequirementHandler(IHttpContextAccessor httpContextAccessor,UserManager<User> user,RoleManager<IdentityRole> role)
    {
        _httpContextAccessor = httpContextAccessor;
        _user = user;
        _role = role;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        CanCreateRequirement requirement,int updatedModelUserId)
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
                    if (user.Id == "")
                    {
                        context.Succeed(requirement);
                        return;
                    }

                    if (_httpContextAccessor.HttpContext != null)
                    {
                        _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                        await _httpContextAccessor.HttpContext.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status401Unauthorized,
                            Message = "Unauthorized. Required admin role."
                        });
                        await _httpContextAccessor.HttpContext.Response.CompleteAsync();
                    }
                }
            }
        }

        context.Fail();
    }
}
// import IAuthorizeationService
// call _authorziationService.AuthorizeAsync(User,100,"policyName");
