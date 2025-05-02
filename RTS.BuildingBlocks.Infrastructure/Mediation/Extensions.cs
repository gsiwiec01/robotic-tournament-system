using Microsoft.Extensions.DependencyInjection;
using RTS.BuildingBlocks.Application.Mediation;

namespace RTS.BuildingBlocks.Infrastructure.Mediation;

public static class Extensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
        
        services.AddTransient(typeof(RequestHandlerWrapper<>));
        services.AddTransient(typeof(RequestHandlerWrapper<,>));

        return services;
    }
}