using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.BuildingBlocks.Infrastructure.Mediation;

public interface IRequestHandlerWrapperBase
{
    Task<object?> Handle(object request, CancellationToken cancellationToken);
}

public interface IRequestHandlerWrapper : IRequestHandlerWrapperBase
{
    Task Handle(IRequest request, CancellationToken cancellationToken);
}

public interface IRequestHandlerWrapper<TResponse> : IRequestHandlerWrapperBase
{
    Task<TResponse> Handle(IRequest<TResponse> request, CancellationToken cancellationToken);
}