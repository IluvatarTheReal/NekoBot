using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NekoBot.Core;
using NekoBot.Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot
{
    public class NekoBot
    {
        private static readonly Logger logger = LogManager.GetLogger("NekoBot");

        private DiscordSocketClient client;
        private CommandHandler commandHandler;
        private string botToken;

        public NekoBot(string _botToken)
        {            
            client = new DiscordSocketClient();
            client.Log += Client_Log;

            var commandService = new CommandService();
            commandHandler = new CommandHandler(client, commandService);


            botToken = _botToken;
        }

        public async Task RunAsync()
        {
            await commandHandler.InstallCommandsAsync();

            await client.LoginAsync(TokenType.Bot, botToken);
            await client.StartAsync();
        }

        private Task Client_Log(LogMessage msg)
        {
            NekoLog.Log(logger, msg);

            return Task.CompletedTask;
        }

    }
}
