using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Csharp.UsersApi.Users.Domain;
using Csharp.UsersApi.Users.Infrastructure;
using Csharp.UsersApi.Configuration;

namespace Csharp.UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Mongo/User")]
        public IActionResult PostMongoUser([FromBody] User user)
        {
            MongoUserRepository userRepository = new MongoUserRepository();
            var userResponse = userRepository.Save(user);
            return Ok(userResponse);
        }

        [HttpGet]
        [Route("Mongo/User/{id}")]
        public IActionResult GetMongoUserById(string id)
        {
            MongoUserRepository userRepository = new MongoUserRepository();
            var userResponse = userRepository.GetUser(id);
            return Ok(userResponse);
        }

        [HttpGet]
        [Route("Mongo/User")]
        public IActionResult GetMongoUser()
        {
            MongoUserRepository userRepository = new MongoUserRepository();
            var userResponse = userRepository.GetUsers();
            return Ok(userResponse);
        }
    }
}
