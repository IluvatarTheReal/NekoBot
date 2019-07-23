using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using NekoBot.Core.Common.BaseClasses;
using NekoBot.Core.Services.MessageBuilder;

namespace NekoBot.Core.Services
{
    public class EmbedBuilderService : NekoServiceBase
    {
        private MessageBuilderService messageBuilderService;

        public EmbedBuilderService(DiscordSocketClient _client, MessageBuilderService _messageBuilderService)
            : base(_client)
        {
            messageBuilderService = _messageBuilderService;
        }


        public Embed GetBannedEmbed(IUser bannedUser, string reason)
        {
            string embedContent = string.Empty;
            embedContent += MessageBuilderService.GetNewLine($"**Banned user:** {bannedUser.Username} ({bannedUser.Id})");
            embedContent += MessageBuilderService.GetNewLine($"**Reason:** {reason}");

            return BuildBaseEmbed("User banned", embedContent, Color.Red).Build();
        }

        public Embed GetUnBannedEmbed(IUser unbannedUser, string reason)
        {
            string embedContent = string.Empty;
            embedContent += MessageBuilderService.GetNewLine($"**Unbanned user:** {unbannedUser.Username} ({unbannedUser.Id})");
            embedContent += MessageBuilderService.GetNewLine($"**Reason:** {reason}");

            return BuildBaseEmbed("User unbanned", embedContent, Color.Green).Build();
        }

        public Embed GetKickedEmbed(IUser kickedUser, string reason)
        {
            string embedContent = string.Empty;
            embedContent += MessageBuilderService.GetNewLine($"**Kicked user:** {kickedUser.Username} ({kickedUser.Id})");
            embedContent += MessageBuilderService.GetNewLine($"**Reason:** {reason}");

            return BuildBaseEmbed("User kicked", embedContent, Color.LightOrange).Build();
        }

        private EmbedBuilder BuildBaseEmbed(string title, string description, Color color)
        {
            return new EmbedBuilder()
                .WithAuthor(context.Message.Author)
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(color);
        }
    }
}
