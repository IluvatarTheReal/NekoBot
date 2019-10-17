using NekoBot.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NekoBot.Infrastructure
{
    public static class NekoConfig
    {
        public static bool Debug { get; set; }
        public static char CommandPrefix { get; set; }
        public static string BotToken { get; set; }


        public static void LoadConfig()
        {
#if DEBUG
            BotToken = "";
            CommandPrefix = '!';
            Debug = true;
#elif RELEASE
            BotToken = "";
            CommandPrefix = '&';
            Debug = false;
#endif

            //TODO Load config file


            //TODO Check if DB file exist
            using (NekoDbContext dbContext = new NekoDbContext())
            {
                //TODO Load DB Config
            }
        }
    }
}
