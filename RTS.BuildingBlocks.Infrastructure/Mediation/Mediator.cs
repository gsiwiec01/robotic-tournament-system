using Microsoft.Extensions.DependencyInjection;
using RTS.BuildingBlocks.Application.Mediation;
using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.BuildingBlocks.Infrastructure.Mediation;

internal class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task Send(IRequest request, CancellationToken cancellationToken)
    {
        var handlerType = typeof(RequestHandlerWrapper<>).MakeGenericType(request.GetType());
        var handler = (IRequestHandlerWrapper) _serviceProvider.GetRequiredService(handlerType);
        
        return handler.Handle(request, cancellationToken);
    }

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var handlerType = typeof(RequestHandlerWrapper<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = (IRequestHandlerWrapper<TResponse>) _serviceProvider.GetRequiredService(handlerType);
        
        return handler.Handle(request, cancellationToken);
    }
}