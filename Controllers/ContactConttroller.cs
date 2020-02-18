using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using web_test_api.Model;

namespace web_test_api.Controllers
{
    [ApiController]
    [Route("info")]
    public class ContactController : ControllerBase
    {
        private static List<User> Users = new List<User>(){
            new User{Id=1, Name="hello", Username="hello@hello.com"},
            new User{Id=2, Name="hello", Username="hello@hello.com"},
            new User{Id=3, Name="hello", Username="hello@hello.com"},
            new User{Id=4, Name="hello", Username="hello@hello.com"},
            new User{Id=5, Name="hello", Username="hello@hello.com"},
        };

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "succes", message = "success get data", data = Users });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { status = "succes", message = "success get data", data = Users.Find(e => e.Id == id) });
        }

        [HttpPost]
        public IActionResult ContactAdd(UserRequest user)
        {

            var userAdd = new User() { Id = 6, Username = user.Username, Name = user.Name };
            Users.Add(userAdd);

            return Ok(new { status = "succes", message = "success add Data", data = Users });
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, JsonPatchDocument<UserRequest> user)
        {

            var users = Users.Find(e => e.Id == id);
            user.ApplyTo(users);

            return Ok(new { status = "succes", message = "success add Data", data = Users.Find(e => e.Id == id) });
        }

    }
}


