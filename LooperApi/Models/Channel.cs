using LooperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooperApi.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Message> Messages { get; set; } = new List<Models.Message>();
        public List<User> Users { get; set; } = new List<Models.User>();

    }
}