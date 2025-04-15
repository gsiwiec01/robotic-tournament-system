using RTS.BuildingBlocks.Application.Mediation;
using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.BuildingBlocks.Infrastructure.Mediation;

public class RequestHandlerWrapper<TRequest> : IRequestHandlerWrapper
    where TRequest : IRequest
{
    private readonly IRequestHandler<TRequest> _handler;
    private readonly IEnumerable<IRequestPipelineBehavior<TRequest, Unit>> _pipelineBehaviors;

    public RequestHandlerWrapper(IRequestHandler<TRequest> handler,
        IEnumerable<IRequestPipelineBehavior<TRequest, Unit>> pipelineBehaviors)
    {
        _handler = handler;
        _pipelineBehaviors = pipelineBehaviors;
    }

    public async Task<object?> Handle(object request, CancellationToken cancellationToken)
    {
        await Handle((TRequest)request, cancellationToken);
        return Unit.Value;
    }

    public Task Handle(IRequest request, CancellationToken cancellationToken)
    {
        var pipeline = _pipelineBehaviors
            .Reverse()
            .Aggregate(
                Handler,
                (next, behavior) => (token) => behavior.Handle((TRequest) request, next, token)
            );

        return pipeline(cancellationToken);

        async Task<Unit> Handler(CancellationToken token)
        {
            await _handler.Handle(request, token);
            return Unit.Value;
        }
    }
}

public class RequestHandlerWrapper<TRequest, TResponse> : IRequestHandlerWrapper<TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;
    private readonly IEnumerable<IRequestPipelineBehavior<TRequest, TResponse>> _pipelineBehaviors;

    public RequestHandlerWrapper(IRequestHandler<TRequest, TResponse> handler,
        IEnumerable<IRequestPipelineBehavior<TRequest, TResponse>> requestPipelineBehavior)
    {
        _handler = handler;
        _pipelineBehaviors = requestPipelineBehavior;
    }

    public async Task<object?> Handle(object request, CancellationToken cancellationToken)
    {
        return Handle((TRequest)request, cancellationToken);
    }

    public Task<TResponse> Handle(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var pipeline = _pipelineBehaviors
            .Reverse()
            .Aggregate(
                Handler,
                (next, behavior) => (token) => behavior.Handle((TRequest) request, next, token)
            );
        
        return pipeline(cancellationToken);
        
        Task<TResponse> Handler(CancellationToken token) => _handler.Handle((TRequest) request, token);
    }
}