using LooperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace LooperApi.Controllers
{
    public class ChannelController : ApiController
    {
        static int count = 0;
        static List<Channel> channelsData = new List<Channel> {
            new Channel(){
                id = 1,
                name = "General",
                users = new List<User>{
                    new User(){ id = 1, username = "Sandeep"},
                    new User(){ id = 2, username = "Sourav"},
                    new User(){ id = 3, username = "Samith"},
                    new User(){ id = 4, username = "Akshay"}
                }
            }
        };

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("user/{userId}/channels")]
        [HttpGet]
        public IHttpActionResult GetUserChannels(int userId)
        {
            var channels = channelsData.Where(c => c.users.Exists(u => u.id == userId));
            var json = new JavaScriptSerializer().Serialize(channels);
            JArray values = JArray.Parse(json);
            return Ok(values);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("channel/{channelId}/messages")]
        [HttpGet]
        public IHttpActionResult GetChannelMessages([FromUri] int limit, int channelId)
        {
            var channelMessages = channelsData.Where(c => c.id == channelId).First().messages;
            channelMessages.ForEach(cm =>
            {
                cm.username = channelsData
                .Find(c => cm.channelId == channelId)
                .users
                .Where(u => u.id == cm.userId).First()
                .username;
            });
            var json = new JavaScriptSerializer().Serialize(channelMessages);
            JArray values = JArray.Parse(json);
            return Ok(values);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("message")]
        [HttpPost]
        public IHttpActionResult SendMessage([FromBody] Message receivedMessage)
        {
            receivedMessage.id = count++;
            channelsData.Where(C => C.id == receivedMessage.channelId).First().messages.Add(receivedMessage);
            return Ok(channelsData);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("login")]
        [HttpPost]
        public IHttpActionResult UserLogin([FromBody] User user)
        {
            if (channelsData.Exists(c => c.users.Exists(u => u.username == user.username))){
                return Ok(channelsData.Find(c => c.users.Exists(u => u.username == user.username)).users.Find(u => u.username == user.username));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
