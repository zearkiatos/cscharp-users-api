using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Shared.Utils;
namespace Csharp.UsersApi.Tests.Users.Domain.Mock {
    public class UserMock : User
    {
        public UserMock(string name, string lastname, string email, IGuidService guidService) : base(name, lastname, email)
        {
            this.id = guidService.NewGuid().ToString();
        }
    }
}