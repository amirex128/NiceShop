using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NiceShop.Application.AI.Common.Behaviours;
using NiceShop.Application.AI.Common.Interfaces;
using NiceShop.Application.AI.Services;

namespace NiceShop.Application.AI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationAIServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddSingleton<ICacheService, CacheService>();
        
        return services;
    }
    public static IServiceCollection AddApplicationAIMediatRServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });
        
        return services;
    }
}
