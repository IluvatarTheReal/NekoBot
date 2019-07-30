using Discord.Commands;
using NekoBot.Core.Attributes;
using NekoBot.Core.Services;
using NekoBot.Core.Services.MessageBuilder;
using NekoBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot.Modules.Admin
{
    [NekoModule("admin")]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        private EmbedBuilderService embedBuilderService;


        public AdminModule(EmbedBuilderService _embedBuilderService)
        {
            embedBuilderService = _embedBuilderService;
        }

        [NekoCommand("kill")][RequireOwner]
        public async Task KillAsync()
        {
            await ReplyAsync("Shutting down in");
            await CountDownAsync(3);
            await ReplyAsync("Shutting down");
            
            if (NekoConfig.Debug)
                Environment.Exit(0);
            else
                "sh NekoBotStop.sh".Bash();
        }

        [NekoCommand("deploy")][RequireOwner]
        public async Task DeployAsync()
        {
            if (NekoConfig.Debug)
            {
                await ReplyAsync("Command not available");
            }
            else
            {
                await ReplyAsync("Getting ready to deploy NekoBot newest version, the bot will shut down during the process.");
                await ReplyAsync("Starting deploy in");
                await CountDownAsync(3);
                await ReplyAsync("See you soon, mreeeow!");
                
                "sh NekoDeploy.sh".Bash();
            }
        }

        [NekoCommand("bash")][RequireOwner]
        public async Task BashAsync([Remainder]string bashLine)
        {
            await ReplyAsync(bashLine.Bash());
        }

        [NekoCommand("script")][RequireOwner]
        public async Task ScriptAsync(string scriptName)
        {
            await ReplyAsync($"sh {scriptName}.sh".Bash());
        }


        private async Task CountDownAsync(int startAt)
        {
            await Task.Delay(1000);
            for (int i = startAt; i > 0; i--)
            {
                await ReplyAsync($"{i} ...");
                await Task.Delay(1000);
            }
        }
    }
}
