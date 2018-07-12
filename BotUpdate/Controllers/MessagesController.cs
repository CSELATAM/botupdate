using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;

namespace BotUpdate.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            if (activity.GetActivityType() == ActivityTypes.Message)
            {
                var client = new ConnectorClient(new Uri(activity.ServiceUrl));

                var reply = activity.CreateReply("Reply: " + activity.Text);

                client.Conversations.ReplyToActivity(reply);

                //client.Conversations.UpdateActivity();

                Console.WriteLine(activity.Text);
            }
        }
    }
}
