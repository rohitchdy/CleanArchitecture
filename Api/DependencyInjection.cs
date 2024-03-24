using Api.Common;
using Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });
        services.AddSingleton<ProblemDetailsFactory, CleanArchitecureProblemDetalsFactory>();
        services.AddMappings();
        return services;
    }
}
