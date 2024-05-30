using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nest;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Constants;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Data.Interceptors;
using NiceShop.Infrastructure.Eita;
using NiceShop.Infrastructure.Elasticsearch;
using NiceShop.Infrastructure.Identity;
using NiceShop.Infrastructure.Payments.Shepa;
using NiceShop.Infrastructure.Policies;
using NiceShop.Infrastructure.Rabbitmq;
using NiceShop.Infrastructure.Sms;

namespace NiceShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "NiceShop";
        });

        services.AddSingleton<IElasticClient>(new ElasticClient(new ConnectionSettings(new Uri(
            configuration["ElasticSearch:Url"] ??
            string.Empty))));
        
        services.AddSingleton<IElasticsearchContext, ElasticsearchContext>();
        services.AddSingleton<IRabbitMqContext, RabbitMqContext>();
        services.AddSingleton<ISmsContext, SmsContext>();
        services.AddSingleton<IEitaContext, EitaContext>();
        services.AddSingleton<IShepaRialContext, ShepaRialContext>();

        services.AddSingleton(TimeProvider.System);


        return services;
    }
    public static IServiceCollection AddInfrastructureAIServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "NiceShop";
        });

        services.AddSingleton(TimeProvider.System);

        return services;
    }
    public static IServiceCollection AddInfrastructureDbServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
    public static IServiceCollection AddInfrastructureAIDbServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        // services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        // services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            // options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<NiceShop.Application.AI.Common.Interfaces.IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        // services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
    public static IServiceCollection AddInfrastructureDbWorkerServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");


        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    public static IServiceCollection AddInfrastructureAuthServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? "test-test-test-test-test-test-test-test");

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddErrorDescriber<PersianIdentityErrorDescriber>()
            .AddApiEndpoints();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

            options.User.RequireUniqueEmail = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
        });

        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IAuthorizationHandler, HasPermissionHandler>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy(ACL.CanCreate, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanCreate)));
            options.AddPolicy(ACL.CanUpdate, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanUpdate)));
            options.AddPolicy(ACL.CanDelete, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanDelete)));
            options.AddPolicy(ACL.CanGet, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanGet)));
            options.AddPolicy(ACL.CanGetAll, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanGetAll)));
        });

        return services;
    }
    
        public static IServiceCollection AddInfrastructureAIAuthServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? "test-test-test-test-test-test-test-test");

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddErrorDescriber<PersianIdentityErrorDescriber>()
            .AddApiEndpoints();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

            options.User.RequireUniqueEmail = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
        });

        services.AddTransient<NiceShop.Application.AI.Common.Interfaces.IIdentityService, IdentityService>();
        services.AddTransient<IAuthorizationHandler, HasPermissionHandler>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy(ACL.CanCreate, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanCreate)));
            options.AddPolicy(ACL.CanUpdate, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanUpdate)));
            options.AddPolicy(ACL.CanDelete, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanDelete)));
            options.AddPolicy(ACL.CanGet, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanGet)));
            options.AddPolicy(ACL.CanGetAll, policy =>
                policy.Requirements.Add(new HasPermissionRequirement(ACL.CanGetAll)));
        });

        return services;
    }
}
