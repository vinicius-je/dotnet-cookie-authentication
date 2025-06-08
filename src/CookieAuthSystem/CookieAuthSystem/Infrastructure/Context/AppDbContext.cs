using CookieAuthSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookieAuthSystem.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoles",
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRoles");
                    });
        }
    }
}
