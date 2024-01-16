using Elastic.Apm.NetCoreAll;
using NiceShop.Application;
using NiceShop.Infrastructure;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Schedulers;
using NiceShop.Web;
using Quartz;
using Quartz.AspNetCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    // .WriteTo.Elasticsearch(
    //     new ElasticsearchSinkOptions(new Uri(builder.Configuration["ElasticSearch:Url"] ?? string.Empty))
    //     {
    //         AutoRegisterTemplate = true,
    //     }).MinimumLevel.Information()
    .WriteTo.Console().MinimumLevel.Warning()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 1000000).MinimumLevel
    .Information()
    .WriteTo.Seq(builder.Configuration["Seq:Host"] ?? string.Empty).MinimumLevel.Warning()
    .CreateLogger();    

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger, dispose: true);
builder.Host.UseSerilog();

builder.Services.AddApplicationServices();
builder.Services.AddApplicationMediatRServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddInfrastructureDbServices(builder.Configuration);
builder.Services.AddInfrastructureAuthServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();
app.UseSerilogRequestLogging();

// app.UseAllElasticApm(builder.Configuration);
if (app.Environment.EnvironmentName == "Local")
{
    await app.InitialiseDatabaseAsync();
}
else
{
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();

app.UseOpenApi();

app.UseSwaggerUi3(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

public partial class Program
{
}
