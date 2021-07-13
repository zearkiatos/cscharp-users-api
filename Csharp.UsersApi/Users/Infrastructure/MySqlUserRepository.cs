using System.Collections.Generic;
using System.Threading.Tasks;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Users.Infrastructure.MySql;
using Microsoft.EntityFrameworkCore;

namespace Csharp.UsersApi.Users.Infrastructure
{
    public class MySqlUserRepository : UserRepository
    {
        private UserContext userContext;

        public MySqlUserRepository()
        {
            this.userContext = new UserContext();
        }
        public User GetUser(string id)
        {
            return Task.Run( () => {return this.userContext.DbUser.FirstOrDefaultAsync(x => x.Id == id); }).Result;
        }

        public List<User> GetUsers()
        {
            return Task.Run( () => {return this.userContext.DbUser.ToListAsync(); }).Result;
        }

        public User Save(User user)
        {
           this.userContext.Add(user);

           this.userContext.SaveChanges();

           return user;
        }
    }
}