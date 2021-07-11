using System;
using Xunit;
using Moq;
using Newtonsoft.Json;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Shared.Utils;
namespace Csharp.UsersApi.Tests.Users.Domainn
{
    public class UserTest
    {
        [Fact]
        public void Should_Create_And_Return_Serialized_User_String()
        {
            var guidServiceMock = new Mock<IGuidService>();

            guidServiceMock.Setup(gs => gs.NewGuid()).Returns(Guid.Parse("fb6ba091-ecfd-4b93-be0d-348a2c5f700c"));

            User user = new User("Pedro", "Capriles", "caprilespe@outlook.com");

            Assert.Equal($"{user.Id}~Pedro~Capriles~caprilespe@outlook.com", user.Serialization());
        }
        [Fact]
        public void Should_Declarate_User_And_Mapper_To_Json()
        {
            User user = new User("Pedro", "Capriles", "caprilespe@outlook.com");

            string json = JsonConvert.SerializeObject(user);

            Assert.Contains($"\"id\":\"{user.Id}\"", json);
            Assert.Contains("\"name\":\"Pedro\"", json);
            Assert.Contains("\"lastname\":\"Capriles\"", json);
            Assert.Contains("\"email\":\"caprilespe@outlook.com\"", json);
        }
    }
}