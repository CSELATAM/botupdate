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
        static Activity _firstActivity = null;
        static int _counter = 0;
        static string _conversationId;
        static string _activityId;

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
                bool isFirstActivity = (_firstActivity == null);

                var client = new ConnectorClient(new Uri(activity.ServiceUrl));

                //client.Conversations.UpdateActivity();
                if(isFirstActivity)
                {
                    Console.WriteLine("Primeira atividade: " + activity.Text);
                    var reply = activity.CreateReply("Primeiro: " + activity.Text);
                    var response = client.Conversations.ReplyToActivity(reply);
                    reply.Id = response.Id;

                    _firstActivity = reply;
                    _conversationId = activity.Conversation.Id;
                    
                    _activityId = reply.Id;
                }
                else
                {
                    _firstActivity.Text = (_counter++).ToString();
                    client.Conversations.UpdateActivity(_firstActivity);
                    var reply = activity.CreateReply("Atualizando o contador...");
                    client.Conversations.ReplyToActivity(reply);
                }
            }
        }
    }
}
