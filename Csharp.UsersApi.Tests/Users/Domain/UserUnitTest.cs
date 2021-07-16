using System;
using Xunit;
using Moq;
using Newtonsoft.Json;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Shared.Utils;
using Csharp.UsersApi.Tests.Users.Domain.Mock;
namespace Csharp.UsersApi.Tests.Users.Domain
{
    public class UserUnitTest
    {
        [Fact]
        public void Should_Create_And_Return_Serialized_User_String()
        {
            var guidServiceMock = new Mock<IGuidService>();

            guidServiceMock.Setup(gs => gs.NewGuid()).Returns(Guid.Parse("fb6ba091-ecfd-4b93-be0d-348a2c5f700c"));

            User user = new UserMock("Pedro", "Capriles", "caprilespe@outlook.com",guidServiceMock.Object);

            Assert.Equal($"fb6ba091-ecfd-4b93-be0d-348a2c5f700c~Pedro~Capriles~caprilespe@outlook.com", user.Serialization());
        }
        [Fact]
        public void Should_Declarate_User_And_Mapper_To_Json()
        {
            var guidServiceMock = new Mock<IGuidService>();

            guidServiceMock.Setup(gs => gs.NewGuid()).Returns(Guid.Parse("fb6ba091-ecfd-4b93-be0d-348a2c5f700c"));

            UserMock user = new UserMock("Pedro", "Capriles", "caprilespe@outlook.com", guidServiceMock.Object);

            string json = JsonConvert.SerializeObject(user);

            Assert.Contains($"\"id\":\"fb6ba091-ecfd-4b93-be0d-348a2c5f700c\"", json);
            Assert.Contains("\"name\":\"Pedro\"", json);
            Assert.Contains("\"lastname\":\"Capriles\"", json);
            Assert.Contains("\"email\":\"caprilespe@outlook.com\"", json);
        }
    }
}