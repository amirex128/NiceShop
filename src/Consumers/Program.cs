using Consumers.Workers;
using NiceShop.Application;
using NiceShop.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

Thread.Sleep(30000);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddInfrastructureDbWorkerServices(builder.Configuration);

builder.Services.AddHostedService<SmsWorker>();
builder.Services.AddHostedService<EmailWorker>();
builder.Services.AddHostedService<EitaWorker>();
builder.Services.AddHostedService<NotificationWorker>();

var host = builder.Build();
host.Run();
