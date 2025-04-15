﻿namespace RTS.BuildingBlocks.Application.Mediation.Contracts;

public interface IRequestHandlerBase;

public interface IRequestHandler<in TRequest> : IRequestHandlerBase
    where TRequest : IRequest
{
    Task Handle(IRequest request, CancellationToken cancellationToken);
}

public interface IRequestHandler<in TRequest, TResponse> : IRequestHandlerBase
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}