using RTS.BuildingBlocks.Application.Mediation.Contracts;

namespace RTS.Modules.UserAccess.Application.Common.Command;

public interface ICommandHandler<in TResponse> : IRequestHandler<TResponse>
    where TResponse : ICommand;