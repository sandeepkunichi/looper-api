using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooperApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Text { get; set; }
        public int ChannelId { get; set; }
    }
}