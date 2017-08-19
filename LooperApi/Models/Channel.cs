using LooperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooperApi.Models
{
    public class Channel
    {
        public int id { get; set; }
        public String name { get; set; }
        public List<Message> messages { get; set; } = new List<Models.Message>();
        public List<User> users { get; set; } = new List<Models.User>();

    }
}