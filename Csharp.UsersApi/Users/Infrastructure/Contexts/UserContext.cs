using Microsoft.EntityFrameworkCore;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Configuration;

namespace Csharp.UsersApi.Users.Infrastructure.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL($"server={Constants.MYSQL_SERVER};port={Constants.MYSQL_PORT};database={Constants.MYSQL_DATABASE};user={Constants.MYSQL_USER};password={Constants.MYSQL_PASSWORD}");
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