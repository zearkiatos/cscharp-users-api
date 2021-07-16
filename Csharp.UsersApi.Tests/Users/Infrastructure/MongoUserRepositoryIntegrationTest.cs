using System;
using Xunit;
using Moq;
using Newtonsoft.Json;
using MongoDB.Driver;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Configuration;
using Csharp.UsersApi.Tests.Builders;
using Csharp.UsersApi.Users.Infrastructure;
using System.Collections.Generic;

namespace Csharp.UsersApi.Tests.Users.Domain
{
    public class MongoUserRepositoryIntegrationTest
    {
        private readonly IMongoCollection<User> user;

        public void ClearData()
        {
            this.user.DeleteMany(x => !String.IsNullOrEmpty(x.Id));
        }
        public MongoUserRepositoryIntegrationTest()
        {
            Constants.MONGO_CONNECTION_STRING = "mongodb://admin:password@localhost";
            Constants.MONGO_DATABASE = "users";
            Constants.MONGO_PORT = "27018";
            var client = new MongoClient($"{Constants.MONGO_CONNECTION_STRING}:{Constants.MONGO_PORT}");
            var database = client.GetDatabase(Constants.MONGO_DATABASE);
            this.user = database.GetCollection<User>(Constants.MONGO_DATABASE);
            this.ClearData();
        }
        [Fact]
        public void Should_Create_And_Return_User()
        {
            MongoUserRepository userRepository = new MongoUserRepository();

            User userResult = userRepository.Save(new UserBuilder().Build());

            User userExpected = this.user.Find(x => x.Id == userResult.Id).FirstOrDefault();

            Assert.Equal(userExpected.Serialization(), userResult.Serialization());
            this.ClearData();
        }

        [Fact]
        public void Should_Get_A_List_Users()
        {
            MongoUserRepository userRepository = new MongoUserRepository();
            this.user.InsertOne(new UserBuilder().Build());
            this.user.InsertOne(new UserBuilder()
            .AddEmail("pcapriles@email.com")
            .AddName("Pedro")
            .AddLastname("Capriles")
            .AddId(Guid.NewGuid().ToString())
            .Build());

            List<User> userResult = userRepository.GetUsers();

            Assert.Equal(userResult.Count, 2);
            Assert.Equal(userResult.ToArray()[0].Id, "fb6ba091-ecfd-4b93-be0d-348a2c5f700c");
            Assert.Equal(userResult.ToArray()[1].Name, "Pedro");
            this.ClearData();
        }

        public void Should_Get_A_SpecificUser_By_Id()
        {
            MongoUserRepository userRepository = new MongoUserRepository();
            User userMocked = new UserBuilder()
            .AddEmail("pcapriles@email.com")
            .AddName("Pedro")
            .AddLastname("Capriles")
            .AddId(Guid.NewGuid().ToString())
            .Build();
            this.user.InsertOne(new UserBuilder().Build());
            this.user.InsertOne(userMocked);

            User userResult = userRepository.GetUser(userMocked.Id);

            Assert.Equal(userResult.Serialization(), userMocked.Serialization());
            this.ClearData();
        }
    }
}