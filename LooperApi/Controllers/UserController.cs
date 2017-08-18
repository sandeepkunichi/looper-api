using LooperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LooperApi.Controllers
{
    public class UserController : ApiController
    {

        List<User> users = new List<User>(2)
        {
            new Models.User { Id = 1, Name = "Sourav"},
            new Models.User { Id = 2, Name = "Varsha"}
        };
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault((u) => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
