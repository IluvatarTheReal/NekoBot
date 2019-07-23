﻿using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NekoBot.Core.Common.Interfaces;
using NekoBot.Core.Extensions;
using NekoBot.Core.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot.Core
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient client;
        private readonly CommandService commandService;
        private readonly IServiceProvider service;

        public CommandHandler(DiscordSocketClient _client, CommandService _commandService)
        {
            commandService = _commandService;
            client = _client;
            service = BuildServiceProvider();

        }

        private IServiceProvider BuildServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection()
            .AddSingleton(client);
            var services = serviceCollection.LoadTypeFrom(Assembly.GetAssembly(typeof(CommandHandler)), typeof(INekoService));

            return serviceCollection.BuildServiceProvider();
        }


        public async Task InstallCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;

            await commandService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: service);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix('!', ref argPos) ||
                message.HasMentionPrefix(client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.

            // Keep in mind that result does not indicate a return value
            // rather an object stating if the command executed successfully.
            var result = await commandService.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: service);

            // Optionally, we may inform the user if the command fails
            // to be executed; however, this may not always be desired,
            // as it may clog up the request queue should a user spam a
            // command.
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }
    }
}
