using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.BuildingBlocks.Infrastructure.Mediation;

public interface IRequestPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequestBase
{
    Task<TResponse> Handle(TRequest request, Func<CancellationToken, Task<TResponse>> next, CancellationToken cancellationToken);
}