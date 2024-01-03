using System.Runtime.InteropServices;
using System.Security.Claims;
using NiceShop.Domain.Constants;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NiceShop.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);
        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
            await _roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanCreate));
            await _roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanUpdate));
            await _roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanDelete));
            await _roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanGet));
            await _roleManager.AddClaimAsync(administratorRole, new Claim("Permission", ACL.CanGetAll));
        }

        var employeeRole = new IdentityRole(Roles.Employee);
        if (_roleManager.Roles.All(r => r.Name != employeeRole.Name))
        {
            await _roleManager.CreateAsync(employeeRole);
            await _roleManager.AddClaimAsync(employeeRole, new Claim("Permission", ACL.CanCreate));
            await _roleManager.AddClaimAsync(employeeRole, new Claim("Permission", ACL.CanUpdate));
            await _roleManager.AddClaimAsync(employeeRole, new Claim("Permission", ACL.CanDelete));
            await _roleManager.AddClaimAsync(employeeRole, new Claim("Permission", ACL.CanGet));
            await _roleManager.AddClaimAsync(employeeRole, new Claim("Permission", ACL.CanGetAll));
        }

        var customerRole = new IdentityRole(Roles.Customer);
        if (_roleManager.Roles.All(r => r.Name != customerRole.Name))
        {
            await _roleManager.CreateAsync(customerRole);
            await _roleManager.AddClaimAsync(customerRole, new Claim("Permission", ACL.CanCreate));
            await _roleManager.AddClaimAsync(customerRole, new Claim("Permission", ACL.CanUpdate));
            await _roleManager.AddClaimAsync(customerRole, new Claim("Permission", ACL.CanDelete));
            await _roleManager.AddClaimAsync(customerRole, new Claim("Permission", ACL.CanGet));
            await _roleManager.AddClaimAsync(customerRole, new Claim("Permission", ACL.CanGetAll));
        }

        var administrator = new User { UserName = "admin@localhost", Email = "admin@localhost" };
        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "@Aa6766581");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        var customer = new User { UserName = "customer@localhost", Email = "customer@localhost" };
        if (_userManager.Users.All(u => u.UserName != customer.UserName))
        {
            await _userManager.CreateAsync(customer, "@Aa6766581");
            if (!string.IsNullOrWhiteSpace(customerRole.Name))
            {
                await _userManager.AddToRolesAsync(customer, new[] { customerRole.Name });
            }
        }

        var employee = new User { UserName = "employee@localhost", Email = "employee@localhost" };
        if (_userManager.Users.All(u => u.UserName != employee.UserName))
        {
            await _userManager.CreateAsync(employee, "@Aa6766581");
            if (!string.IsNullOrWhiteSpace(employeeRole.Name))
            {
                await _userManager.AddToRolesAsync(employee, new[] { employeeRole.Name });
            }
        }

        await _context.SaveChangesAsync();
    }
}
