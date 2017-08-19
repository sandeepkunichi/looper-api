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
            new Models.User { id = 1, username = "Sourav"},
            new Models.User { id = 2, username = "Varsha"}
        };
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault((u) => u.id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
