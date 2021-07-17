using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Csharp.UsersApi.Users.Infrastructure
{
    public class MySqlUserRepository : UserRepository
    {
        private UserContext userContext;

        public MySqlUserRepository(DbContext context)
        {
            this.userContext = (UserContext)context;
            this.userContext.Database.EnsureCreated();
        }
        public User GetUser(string id)
        {
            return Task.Run( () => {return this.userContext.Users.FirstOrDefaultAsync(x => x.Id == id); }).Result;
        }

        public List<User> GetUsers()
        {
            return Task.Run( () => {return this.userContext.Users.ToListAsync(); }).Result;
        }

        public User Save(User user)
        {
           this.userContext.Users.Add(user);

           this.userContext.SaveChanges();

           return user;
        }
    }
}