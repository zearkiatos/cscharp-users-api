using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Shared.Utils;
namespace Csharp.UsersApi.Tests.Builders
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            this.user = new User("Amy Lee", "Martin", "amy.lee@email.com");
            this.user.Id = "fb6ba091-ecfd-4b93-be0d-348a2c5f700c";
            this.user.Name = "Amy Lee";
            this.user.Lastname = "Martin";
        }

        public UserBuilder AddId(string id)
        {
            this.user.Id = id;
            return this;
        }

        public UserBuilder AddName(string name)
        {
            this.user.Name = name;
            return this;
        }

        public UserBuilder AddLastname(string lastname)
        {
            this.user.Lastname = lastname;
            return this;
        }

        public UserBuilder AddEmail(string email)
        {
            this.user.Email = email;
            return this;
        }

        public User Build()
        {
            return this.user;
        }
    }
}