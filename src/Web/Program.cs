using NiceShop.Application;
using NiceShop.Infrastructure;
using NiceShop.Infrastructure.Data;
using NiceShop.Web;
using Serilog;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

// for inject app setting file to class and get that with IOption<ConfigAppsetting> with DI
// builder.Services.AddOptions();
// builder.Services.Configure<ConfigAppsetting>(builder.Configuration.GetSection(""));

builder.Services.AddMemoryCache();

builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

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
