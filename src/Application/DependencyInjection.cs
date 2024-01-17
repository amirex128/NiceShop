using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NiceShop.Application.Common.Behaviours;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Services;

namespace NiceShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddSingleton<IRabbitmqService, RabbitmqService>();
        services.AddSingleton<ISmsService, SmsService>();
        services.AddSingleton<ICacheService, CacheService>();
        services.AddSingleton<IEitaService, EitaService>();
        services.AddSingleton<IPaymentService, PaymentService>();
        
        return services;
    }
    public static IServiceCollection AddApplicationMediatRServices(this IServiceCollection services)
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
