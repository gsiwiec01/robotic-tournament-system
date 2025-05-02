using RTS.BuildingBlocks.Domain.Exceptions;

namespace RTS.Modules.UserAccess.Domain.Exceptions;

public class EmailFormatIsInvalidException : DomainException
{
    public EmailFormatIsInvalidException() : base("Email format is invalid")
    {
    }
}