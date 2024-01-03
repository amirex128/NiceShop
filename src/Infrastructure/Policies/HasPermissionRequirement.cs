using Microsoft.AspNetCore.Authorization;

namespace NiceShop.Infrastructure.Policies;

public class HasPermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }

    public HasPermissionRequirement(string permission)
    {
        Permission = permission;
    }
}