namespace RTS.BuildingBlocks.Application.Mediation.Contracts;

public interface IRequestPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequestBase
{
    Task<TResponse> Handle(TRequest request, Func<CancellationToken, Task<TResponse>> next, CancellationToken cancellationToken);
}