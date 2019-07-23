using Discord;
using Discord.Commands;
using NekoBot.Core.Attributes;
using NekoBot.Core.Common.BaseClasses;
using NekoBot.Core.Services;
using NekoBot.Core.Services.MessageBuilder;
using NekoBot.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot.Modules.Moderation
{
    [NekoModule("mod")]
    public class ModerationModule : NekoModuleBase
    {
        private EmbedBuilderService embedBuilderService;
        private ModerationService moderationService;
        private MessageBuilderService messagebuilderService;

        public ModerationModule(EmbedBuilderService _embedBuilderService, ModerationService _moderationService, MessageBuilderService _messagebuilderService)
        {
            embedBuilderService = _embedBuilderService;
            moderationService = _moderationService;
            messagebuilderService = _messagebuilderService;
        }

        [NekoCommand("kick")]//TODO User has permission
        public async Task KickUser(IGuildUser user, [Remainder]string reason)
        {
            InitService();

            await moderationService.KickUser(user,reason);            

            await ReplyAsync(embed: embedBuilderService.GetKickedEmbed(user, reason));
            await Context.Message.DeleteAsync();
        }

        [NekoCommand("ban")]//TODO User has permission
        public async Task BanUser(IGuildUser user, [Remainder]string reason)
        {
            InitService();
            
            await moderationService.BanUser(user, reason);

            await ReplyAsync(embed: embedBuilderService.GetBannedEmbed(user, reason));
            await Context.Message.DeleteAsync();
        }

        [NekoCommand("unban")]//TODO User has permission
        public async Task UnBannedBoi(IGuildUser user, [Remainder]string reason)
        {
            InitService();
            
            await moderationService.UnBanUser(user, reason);            

            await ReplyAsync(embed: embedBuilderService.GetUnBannedEmbed(user, reason));
            await Context.Message.DeleteAsync();
        }

        [NekoCommand("test")]
        public async Task Test()
        {
            using(NekoDbContext dbContext = new NekoDbContext())
            {
                var modLog = dbContext.ModerationLogs;

                foreach (var item in modLog)
                {
                    await ReplyAsync( String.Format("{0,5} {1,5} {2,5} {3,5}", item.Timestamp, item.Action, item.Reason, $"<@{item.TargetedUserId}>"));
                }
            }
        }


        private void InitService()
        {
            embedBuilderService.SetContext(Context);
            moderationService.SetContext(Context);
        }
    }
}
