using Discord;
using Discord.WebSocket;
using NekoBot.Core.Common.BaseClasses;
using NekoBot.Infrastructure.Data;
using NekoBot.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot.Core.Services
{
    public class ModerationService : NekoServiceBase
    {
        public ModerationService(DiscordSocketClient _client)
            : base(_client)
        {
        }

        public async Task KickUser(IGuildUser user, string reason)
        {            
            //await user.KickAsync(reason);
            await AddModerationLog(ModerationLog.ModAction.Kick, user, reason);
        }

        public async Task BanUser(IGuildUser user, string reason)
        {
            await context.Guild.AddBanAsync(user, reason: reason);
            await AddModerationLog(ModerationLog.ModAction.Ban, user, reason);
        }

        public async Task UnBanUser(IGuildUser user, string reason)
        {
            await context.Guild.RemoveBanAsync(user);
            await AddModerationLog(ModerationLog.ModAction.Unban, user, reason);
        }


        private async Task AddModerationLog(ModerationLog.ModAction action, IGuildUser user, string reason)
        {
            using (NekoDbContext dbContext = new NekoDbContext())
            {
                ModerationLog newModerationLog = new ModerationLog
                {
                    ExecutingUserId = context.User.Id,
                    ExecutingUsername = context.User.Username,
                    TargetedUserId = user.Id,
                    TargetUsername = user.Username,
                    Reason = reason,
                    Timestamp = DateTime.UtcNow
                };

                dbContext.ModerationLogs.Add(newModerationLog);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
