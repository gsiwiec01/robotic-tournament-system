using RTS.BuildingBlocks.Domain.Exceptions;

namespace RTS.Modules.UserAccess.Domain.Exceptions;

public class InvalidLastNameException : DomainException
{
    public InvalidLastNameException() : base("First name must be between 3 and 50 characters long.")
    {
    }
}