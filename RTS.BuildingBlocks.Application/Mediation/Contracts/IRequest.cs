namespace RTS.BuildingBlocks.Application.Mediation.Contracts;

public interface IRequestBase;

public interface IRequest : IRequestBase;

public interface IRequest<TResponse> : IRequestBase;