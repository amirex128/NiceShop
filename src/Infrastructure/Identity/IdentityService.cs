using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Identity;

public class IdentityService(
    UserManager<User> userManager,
    IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService,
    IConfiguration configuration)
    : IIdentityService
{
    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await userClaimsPrincipalFactory.CreateAsync(user);

        var result = await authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var keyString = configuration["Jwt:Key"] ?? "test-test-test-test-test-test-test-test";

        if (keyString.Length < 16)
        {
            throw new Exception("JWT Key must be at least 16 characters long.");
        }

        var key = Encoding.ASCII.GetBytes(keyString);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName ?? throw new InvalidOperationException("Username is null")),
            new(ClaimTypes.NameIdentifier, user.Id ?? throw new InvalidOperationException("User Id is null")),
            new(ClaimTypes.MobilePhone,
                user.PhoneNumber ?? throw new InvalidOperationException("User Phone Number is null")),
            new(ClaimTypes.Email, user.Email ?? throw new InvalidOperationException("User Email is null")),
            new(ClaimTypes.Surname, user.IsAdmin ? "Yes" : "No"),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(9999),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
