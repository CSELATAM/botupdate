using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotUpdate
{
    public class AppBotConfig
    {
        string _app;
        string _appPassword;

        public string App => _app;
        public string AppPassword => _appPassword;

        public AppBotConfig(string app, string appPassword)
        {
            _app = app;
            _appPassword = appPassword;
        }
    }
}
