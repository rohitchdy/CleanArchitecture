using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Commands.Register.RegisterCommand;
using ErrorOr;
using Application.Services.Authentication.Common;
using Application.Authentication.Common.Behaviors;
using FluentValidation;
using Application.Authentication.Commands.Register;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(typeof(DependencyInjection).Assembly);
        service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return service;
    }
}
