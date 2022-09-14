using Api.Common.Mapping;
using Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CleanArchitecureProblemDetalsFactory>();
        services.AddMappings();
        return services;
    }
}
