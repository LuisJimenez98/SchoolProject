using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Qualification.Application.Behaviors;
using System.Reflection;

namespace Qualification.Application.Wrappers;
public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
