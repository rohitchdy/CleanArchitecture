using Api;
using Application;
using Infrastructure;
using Infrastructure.DatabaseContext;
using Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var serilogConfiguration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("logging.Configuration.json")
    .Build();

    // Add support for logging with Serilog
    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(serilogConfiguration)
        );

    builder.Services.AddEndpointsApiExplorer();

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);


    Log.Information("Starting Application");
    var app = builder.Build();

    var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();

    app.UseSession();


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseMiddleware<JwtTokenMiddleware>();
    }
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();


    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
