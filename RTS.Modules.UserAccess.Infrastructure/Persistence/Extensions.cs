using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RTS.Modules.UserAccess.Infrastructure.Data;

namespace RTS.Modules.UserAccess.Infrastructure.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UserAccessContext>(ctxOptions =>
        {
            ctxOptions.UseNpgsql(connectionString, opt =>
            {
                opt.MigrationsAssembly(typeof(UserAccessContext).Assembly.FullName);
            });
        });
        
        return services;
    }
}