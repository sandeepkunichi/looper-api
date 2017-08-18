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

namespace LooperApi.Controllers
{
    public class ChannelController : ApiController
    {
        static List<Channel> channelsData = new List<Channel> {
            new Channel(){
                Id = 1,
                Users = new List<User>{
                    new User(){ Id = 1, Name = "Sandeep"},
                    new User(){ Id = 2, Name = "Sourav"}
                }
            },
            new Channel(){
                Id = 2,
                Users = new List<User>{
                    new User(){ Id = 3, Name = "Samith"},
                    new User(){ Id = 4, Name = "Akshay"}
                }
            }
        };

        [Route("user/{userId}/channels")]
        [HttpGet]
        public IHttpActionResult GetUserChannels(int userId)
        {
            var channels = channelsData.Where(c => c.Users.Exists(u => u.Id == userId));
            var json = new JavaScriptSerializer().Serialize(channels);
            JArray values = JArray.Parse(json);
            return Ok(values);
        }

        [Route("channel/{channelId}/messages")]
        [HttpGet]
        public IHttpActionResult GetChannelMessages([FromUri] int limit, int channelId)
        {
            var channelMessages = channelsData.Where(c => c.Id == channelId).First().Messages;
            var json = new JavaScriptSerializer().Serialize(channelMessages);
            JArray values = JArray.Parse(json);
            return Ok(values);
        }

        [Route("message")]
        [HttpPost]
        public IHttpActionResult SendMessage([FromBody] Message receivedMessage)
        {
            channelsData.Where(C => C.Id == receivedMessage.ChannelId).First().Messages.Add(receivedMessage);
            return Ok(channelsData);
        }
    }
}
