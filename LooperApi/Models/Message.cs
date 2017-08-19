using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooperApi.Models
{
    public class Message
    {
        public int id { get; set; }
        public int userId { get; set; }
        public String text { get; set; }
        public int channelId { get; set; }
        public String username { get; set; }
    }
}