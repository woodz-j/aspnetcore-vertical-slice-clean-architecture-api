using Microsoft.EntityFrameworkCore;
using MyApi.Domain.Entities;

namespace MyApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasIndex(x => x.Email)
                .IsUnique();

            entity.Property(x => x.PasswordHash)
                .IsRequired();

            entity.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Email = "admin@test.com",
                //PasswordHash = "Password123!", // TEMP (we'll hash next step)
                PasswordHash = "AQAAAAIAAYagAAAAELqKiy3aTopPm6hxrTuuGjL/94HrJp2z10/RP85PdOh8AxEHIDiB4V1rAwh30T2Hnw==",
                Role = "Admin",
                CreatedUtc = new DateTime(2025, 3, 24, 12, 0, 0, DateTimeKind.Utc)
            },
            new User
            {
                Id = 2,
                Email = "user@test.com",
                //PasswordHash = "Password123!",
                PasswordHash = "AQAAAAIAAYagAAAAEMG2RQMUT2Y271SAT61FoEtW/c9klI8kUSq9NZrL9Y2IvQ+TIKsE6w+tHqb3K4t50g==",
                Role = "User",
                CreatedUtc = new DateTime(2025, 3, 24, 12, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}