using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Infrastructure.DatabaseContext;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region User
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasColumnType("Varchar(50)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnType("Varchar(250)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.ContactNumber)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasDefaultValue(true);
        #endregion

        #region Role
        modelBuilder.Entity<Role>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<Role>()
            .Property(r => r.Name)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<Role>()
            .Property(r => r.IsAdmin)
            .HasDefaultValue(false)
            .IsRequired();
        modelBuilder.Entity<Role>()
            .Property(r => r.IsActive)
            .HasDefaultValue(true)
            .IsRequired();
        #endregion
    }
}
