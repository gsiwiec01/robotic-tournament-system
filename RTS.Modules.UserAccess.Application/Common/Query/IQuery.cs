using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.Modules.UserAccess.Application.Common.Query;

public interface IQuery<TResponse> : IRequest<TResponse>;