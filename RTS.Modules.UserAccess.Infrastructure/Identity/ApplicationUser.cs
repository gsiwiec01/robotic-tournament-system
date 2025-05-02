using Microsoft.AspNetCore.Identity;
using RTS.Modules.UserAccess.Domain.Entities;

namespace RTS.Modules.UserAccess.Infrastructure.Identity;

internal class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    
    public User ToDomain()
    {
        return User.Create(Id, FirstName, MiddleName, LastName, Email!);
    }

    public static ApplicationUser FromDomain(User user)
    {
        return new ApplicationUser()
        {
            Id = user.Id,
            UserName = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Email = user.Email,
        };
    }
}