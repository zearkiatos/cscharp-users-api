using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Configuration;

namespace Csharp.UsersApi.Users.Infrastructure.MySql
{
    public class UserContext : DbContext
  {
    public DbSet<User> DbUser { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL($"server={Constants.MYSQL_SERVER};database={Constants.MYSQL_DATABASE};user={Constants.MYSQL_USER};password={Constants.MYSQL_PASSWORD}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(d => d.Lastname).IsRequired();
        entity.Property(d => d.Email).IsRequired();
      });
    }
  }
}