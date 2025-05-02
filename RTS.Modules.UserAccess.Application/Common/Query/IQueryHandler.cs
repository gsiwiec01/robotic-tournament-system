using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.Modules.UserAccess.Application.Common.Query;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>;