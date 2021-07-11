using System;

namespace Csharp.UsersApi.Shared.Utils
{
    public class GuidService : IGuidService
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}