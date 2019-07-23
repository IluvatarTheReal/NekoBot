using Discord.Commands;
using Discord.WebSocket;
using NekoBot.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NekoBot.Core.Common.BaseClasses
{
    public class NekoServiceBase : INekoService
    {
        protected DiscordSocketClient client;
        protected SocketCommandContext context;

        protected NekoServiceBase(DiscordSocketClient _client)
        {
            client = _client;
        }


        public void SetContext(SocketCommandContext _context)
            => context = _context;
        
    }
}
