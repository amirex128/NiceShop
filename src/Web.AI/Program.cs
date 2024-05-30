using NiceShop.Application.AI;
using NiceShop.Infrastructure;
using NiceShop.Web.AI;
using Serilog;

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

builder.Services.AddApplicationAIServices();
builder.Services.AddApplicationAIMediatRServices();
builder.Services.AddInfrastructureAIServices(builder.Configuration);
builder.Services.AddInfrastructureAIDbServices(builder.Configuration);
builder.Services.AddInfrastructureAIAuthServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();
app.UseSerilogRequestLogging();

// app.UseAllElasticApm(builder.Configuration);
// await app.InitialiseDatabaseAsync();

if (app.Environment.EnvironmentName == "Local")
{
}
else
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

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

namespace NiceShop.Web.AI
{
    public partial class Program
    {
    }
}
