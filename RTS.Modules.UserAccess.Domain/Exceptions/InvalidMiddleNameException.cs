using RTS.BuildingBlocks.Domain.Exceptions;

namespace RTS.Modules.UserAccess.Domain.Exceptions;

public class InvalidMiddleNameException : DomainException
{
    public InvalidMiddleNameException() : base("Middle name must be between 3 and 50 characters if provided")
    {
    }
}