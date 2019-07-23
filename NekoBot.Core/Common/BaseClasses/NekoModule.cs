using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NekoBot.Core.Common.BaseClasses
{
    public abstract class NekoModuleBase : ModuleBase<SocketCommandContext>
    {
        public SocketUser GetUserFromMention(string userMention)
        {
            ulong userId = ulong.Parse(Regex.Replace(userMention, @"\D", ""));

            return Context.Client.GetUser(userId);
        }
    }
}
