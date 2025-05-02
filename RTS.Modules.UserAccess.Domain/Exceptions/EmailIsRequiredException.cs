using RTS.BuildingBlocks.Domain.Exceptions;

namespace RTS.Modules.UserAccess.Domain.Exceptions;

public class EmailIsRequiredException : DomainException
{
    public EmailIsRequiredException() : base("Email is required.")
    {
    }
}