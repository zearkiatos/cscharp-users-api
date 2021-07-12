using System.Collections.Generic;
using MongoDB.Driver;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Configuration;
namespace Csharp.UsersApi.Users.Infrastructure
{
    public class MongoUserRepository : UserRepository
    {

        private readonly IMongoCollection<User> user;

        public MongoUserRepository()
        {
            var client = new MongoClient($"{Constants.MONGO_CONNECTION_STRING}:{Constants.MONGO_PORT}");
            var database = client.GetDatabase(Constants.MONGO_DATABASE);

            this.user = database.GetCollection<User>(Constants.MONGO_DATABASE);
        }

        public User GetUser(string id)
        {
            return this.user.Find<User>(x => x.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return this.user.Find<User>(user => true).ToList();
        }

        public User Save(User user)
        {
            this.user.InsertOne(user);
            return user;
        }
    }
}