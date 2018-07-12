using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotUpdate
{
    public class AppBotConfig
    {
        MicrosoftAppCredentials _creds;
        
        public MicrosoftAppCredentials Credential => _creds;

        public AppBotConfig(string app, string appPassword)
        {
            Console.WriteLine("appId: " + app);
            Console.WriteLine("appPwd: " + appPassword);
            _creds = new MicrosoftAppCredentials(app, appPassword);
        }
    }
}
