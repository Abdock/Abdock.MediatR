using System.Reflection;
using Abdock.MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Abdock.MediatR.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services, params string[] assemblyNames)
    {
        var handlerType = typeof(IRequestHandler<,>);
        var handlers = assemblyNames.SelectMany(assemblyName => Assembly.Load(assemblyName)
            .GetTypes()
            .Where(e => e is { IsClass: true, IsAbstract: false } && e.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == handlerType)));
        foreach (var handler in handlers)
        {
            var serviceType = handler.GetInterfaces()
                .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == handlerType);
            services.AddTransient(serviceType, handler);
        }

        return services;
    }

    public static IServiceCollection AddMediatR(this IServiceCollection services, params Assembly[] assemblies)
    {
        var handlerType = typeof(IRequestHandler<,>);
        var handlers = assemblies.SelectMany(assembly => assembly
            .GetTypes()
            .Where(e => e is { IsClass: true, IsAbstract: false } && e.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == handlerType)));
        foreach (var handler in handlers)
        {
            var serviceType = handler.GetInterfaces()
                .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == handlerType);
            services.AddTransient(serviceType, handler);
        }

        return services;
    }
}