using Microsoft.AspNetCore.Identity;
using RTS.Modules.UserAccess.Application.Contracts;
using RTS.Modules.UserAccess.Domain.Entities;

namespace RTS.Modules.UserAccess.Infrastructure.Identity;

internal class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public Task CreateAsync(User user)
    {
        var identityUser = ApplicationUser.FromDomain(user);
        return _userManager.CreateAsync(identityUser);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var identityUser = await _userManager.FindByIdAsync(id.ToString());
        return identityUser?.ToDomain();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var identityUser = await _userManager.FindByEmailAsync(email);
        return identityUser?.ToDomain();
    }
}