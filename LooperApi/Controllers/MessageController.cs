using LooperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LooperApi.Controllers
{
     public class MessageController : ApiController
    {
        public IHttpActionResult GetUserMessages(int id)
        {
            //var user = users.FirstOrDefault((u) => u.Id == id);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            return Ok();
        }
    }
}
