using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using Newtonsoft.Json;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Configuration;
using Csharp.UsersApi.Tests.Builders;
using Csharp.UsersApi.Users.Infrastructure;
using Csharp.UsersApi.Tests.Users.Infrastructure.Mock;

namespace Csharp.UsersApi.Tests.Users.Domain
{
    public class MySqlUserRepositoryIntegrationTest
    {
        private UserContextMock userContext;
        public void ClearData()
        {
            List<User> users = this.userContext.Users.ToList();
            foreach (User user in users)
            {
                this.userContext.Users.Remove(user);
                this.userContext.SaveChanges();
            }
        }
        public MySqlUserRepositoryIntegrationTest()
        {
            this.userContext = new UserContextMock();
            this.userContext.Database.EnsureCreated();
            this.ClearData();
        }
        [Fact]
        public void Should_Create_And_Return_User()
        {
            MySqlUserRepository userRepository = new MySqlUserRepository(new UserContextMock());

            User userResult = userRepository.Save(new UserBuilder().Build());

            User userExpected = this.userContext.Users.FirstOrDefault(x => x.Id == userResult.Id);

            Assert.Equal(userExpected.Serialization(), userResult.Serialization());
            this.ClearData();
        }

        [Fact]
        public void Should_Get_A_List_Users()
        {
            MySqlUserRepository userRepository = new MySqlUserRepository(new UserContextMock());
            this.userContext.Add(new UserBuilder().Build());
            this.userContext.Add(new UserBuilder()
            .AddEmail("pcapriles@email.com")
            .AddName("Pedro")
            .AddLastname("Capriles")
            .AddId(Guid.NewGuid().ToString())
            .Build());
            this.userContext.SaveChanges();

            List<User> userResult = userRepository.GetUsers();

            Assert.Equal(userResult.Count, 2);
            Assert.Equal(userResult.ToArray()[0].Name, "Pedro");
            Assert.Equal(userResult.ToArray()[1].Id, "fb6ba091-ecfd-4b93-be0d-348a2c5f700c");
            this.ClearData();
        }

        public void Should_Get_A_SpecificUser_By_Id()
        {
            MySqlUserRepository userRepository = new MySqlUserRepository(new UserContextMock());
            User userMocked = new UserBuilder()
            .AddEmail("pcapriles@email.com")
            .AddName("Pedro")
            .AddLastname("Capriles")
            .AddId(Guid.NewGuid().ToString())
            .Build();
            this.userContext.Add(new UserBuilder().Build());
            this.userContext.Add(userMocked);

            User userResult = userRepository.GetUser(userMocked.Id);

            Assert.Equal(userResult.Serialization(), userMocked.Serialization());
            this.ClearData();
        }
    }
}