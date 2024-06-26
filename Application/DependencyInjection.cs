﻿using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Authentication.Common.Behaviors;
using FluentValidation;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return service;
    }
}
