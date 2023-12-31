using Consumers;
using NiceShop.Application;
using NiceShop.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddHostedService<SmsOtpWorker>();

var host = builder.Build();
host.Run();
