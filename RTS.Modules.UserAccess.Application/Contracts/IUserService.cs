using RTS.Modules.UserAccess.Domain.Entities;

namespace RTS.Modules.UserAccess.Application.Contracts;

public interface IUserService
{
    Task CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
}