using NiceShop.Domain.Entities;

namespace NiceShop.Application.AI.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);
    public string GenerateJwtToken(User user);
    public Task<User?> GetUserAsync();


}
