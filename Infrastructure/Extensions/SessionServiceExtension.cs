using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;
public static class SessionServiceExtension
{
    public static IServiceCollection AddSessionServiceConfiguration(this IServiceCollection services)
    {
        services.AddSession(options =>
        {
            options.Cookie.Name = "Application.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(360);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        return services;
    }
}
