using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Policies;

public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public HasPermissionHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    private async Task<IEnumerable<string>> getPermissionsAsync(IdentityRole role)
    {
        var claims = await _roleManager.GetClaimsAsync(role);
        return claims.Where(c => c.Type == "Permission").Select(c => c.Value);
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
    {
        var user = await _userManager.GetUserAsync(context.User);
        if (user == null)
        {
            return;
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var roleName in userRoles)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                // Assuming you have a method GetPermissionsAsync that returns the permissions of a role
                var rolePermissions = await getPermissionsAsync(role);
                if (rolePermissions.Contains(requirement.Permission))
                {
                    context.Succeed(requirement);
                    return;
                }
            }
        }
    }}
