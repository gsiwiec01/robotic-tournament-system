using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RTS.Modules.UserAccess.Infrastructure.Identity;

namespace RTS.Modules.UserAccess.Infrastructure.Data;

internal class UserAccessContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public UserAccessContext(DbContextOptions<UserAccessContext> options) : base(options)
    {
    }
}