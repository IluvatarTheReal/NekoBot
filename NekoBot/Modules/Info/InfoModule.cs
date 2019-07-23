using Discord.Commands;
using NekoBot.Core.Attributes;
using NekoBot.Core.Services.MessageBuilder;
using System;
using System.Collections.Generic;
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

        [NekoCommand("a")]
        public async Task AnnouncementAsync(string title, [Remainder]string content)
        {          
            await ReplyAsync(messageBuilderService.BuildAnnoucementMessage(title, content));
        }
        
    }
}
