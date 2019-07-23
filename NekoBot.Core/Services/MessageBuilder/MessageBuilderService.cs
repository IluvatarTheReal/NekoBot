using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;
using NekoBot.Core.Common.BaseClasses;
using NekoBot.Infrastructure;

namespace NekoBot.Core.Services.MessageBuilder
{
    public class MessageBuilderService : NekoServiceBase
    {
        public MessageBuilderService(DiscordSocketClient _client)
            : base(_client)
        {            
        }        

        public static string GetNewLine(string txt)
        {
            return $"{txt}\r\n";
        }

        public static string GetBoldLine(string txt)
        {
            return GetNewLine($"**{txt}**");
        }

        public static string GetItalicLine(string txt)
        {
            return GetNewLine($"*{txt}*");
        }

        public string BuildAnnoucementMessage(string title, string msgContent)
        {
            string message = string.Empty;

            message += GetBoldLine($"{title}");
            message += GetBoldLine("----------------------------------------");
            message += GetNewLine(msgContent);
            message += GetBoldLine("----------------------------------------");

            return message;
        }
    }
}
