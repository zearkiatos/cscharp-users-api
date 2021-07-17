using Microsoft.EntityFrameworkCore;
using Csharp.UsersApi.Configuration;
using Csharp.UsersApi.Users.Infrastructure.Contexts;
namespace Csharp.UsersApi.Tests.Users.Infrastructure.Mock
{
    public class UserContextMock : UserContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Constants.MYSQL_SERVER = "localhost";
            Constants.MYSQL_DATABASE = "users";
            Constants.MYSQL_USER = "admin";
            Constants.MYSQL_PASSWORD = "password";
            Constants.MYSQL_PORT = "3307";
            optionsBuilder.UseMySQL($"server={Constants.MYSQL_SERVER};port={Constants.MYSQL_PORT};database={Constants.MYSQL_DATABASE};user={Constants.MYSQL_USER};password={Constants.MYSQL_PASSWORD}");
        }
    }
}