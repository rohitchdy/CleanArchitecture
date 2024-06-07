using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace Infrastructure.Extensions;

public static class SwaggerServiceExtensions
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean Architecture APIs",
                Version = "v1",
                Description = "To test API from Swagger",
                Contact = new OpenApiContact
                {
                    Name = "API Support",
                    Url = new Uri("https://www.api.com/support"),
                    Email = "supportapi@example.com"
                },
                TermsOfService = new Uri("https://www.api.com/termsandservices"),
            });

            config.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
        });

        services.AddSwaggerGenNewtonsoftSupport();
    }
}
