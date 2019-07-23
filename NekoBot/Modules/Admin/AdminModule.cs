using Discord.Commands;
using NekoBot.Core.Attributes;
using NekoBot.Core.Services;
using NekoBot.Core.Services.MessageBuilder;
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


        
    }
}
