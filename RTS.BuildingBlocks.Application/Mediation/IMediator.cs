using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.BuildingBlocks.Application.Mediation;

public interface IMediator
{
    Task Send(IRequest request, CancellationToken cancellationToken);
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}