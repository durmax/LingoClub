using Application.Interfaces;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
    {
        public DbSet<User> Users { get; set; }  // from Domain

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.HasIndex(u => u.Email)
                      .IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
