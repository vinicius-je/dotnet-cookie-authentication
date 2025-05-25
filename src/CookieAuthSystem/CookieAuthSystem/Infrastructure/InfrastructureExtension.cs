using CookieAuthSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CookieAuthSystem.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static void ConfigureDabatase(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString), ServiceLifetime.Scoped);
        }
    }
}
