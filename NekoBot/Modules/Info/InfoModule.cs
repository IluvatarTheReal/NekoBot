using Discord.Commands;
using NekoBot.Core.Attributes;
using NekoBot.Core.Services.MessageBuilder;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot.Modules.Info
{
    [NekoModule("info")]
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private MessageBuilderService messageBuilderService;

        public InfoModule(MessageBuilderService _messageBuilderService)
        {
            messageBuilderService = _messageBuilderService;
        }

        [NekoCommand("bot")]
        public async Task BotInfoAsync()
        {
            string msg = string.Empty;
            msg += MessageBuilderService.GetNewLine($"**Machine:** {Environment.MachineName}");
            msg += MessageBuilderService.GetNewLine($"**Version:** {NekoInfo.Version}");
            msg += MessageBuilderService.GetNewLine($"**Author:** {NekoInfo.Author}");
            msg += MessageBuilderService.GetNewLine($"**Git repo:** {NekoInfo.GitRepository}", true);
            await ReplyAsync(messageBuilderService.BuildAnnoucementMessage(":desktop: NekoBot Information", msg));
        }

        [NekoCommand("a")]
        public async Task AnnouncementAsync(string title, [Remainder]string content)
        {
            await ReplyAsync(messageBuilderService.BuildAnnoucementMessage(title, content));
        }

    }
}
