using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using RTS.Modules.UserAccess.Domain.Exceptions;

namespace RTS.Modules.UserAccess.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public string FullName => string.Join(' ',
        new[] { FirstName, MiddleName, LastName }.Where(x => !string.IsNullOrWhiteSpace(x)));

    private User()
    {
    }

    public static User Create(Guid id, string firstName, string middleName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length is < 3 or > 50)
            throw new InvalidFirstNameException();

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length is < 3 or > 50)
            throw new InvalidLastNameException();

        if (!string.IsNullOrWhiteSpace(middleName) && middleName.Length is < 3 or > 50)
            throw new InvalidMiddleNameException();

        if (string.IsNullOrWhiteSpace(email))
            throw new EmailIsRequiredException();

        if (!new EmailAddressAttribute().IsValid(email))
            throw new EmailFormatIsInvalidException();

        return new User()
        {
            Id = id,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Email = email
        };
    }
}