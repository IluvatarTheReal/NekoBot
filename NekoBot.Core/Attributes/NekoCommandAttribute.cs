using Discord.Commands;
using NekoBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NekoBot.Core.Attributes
{
    public class NekoCommandAttribute : CommandAttribute
    {
        public NekoCommandAttribute() : base()
        {
        }
        public NekoCommandAttribute(string commandName) : base(commandName)
        {
            NekoLog.Log($" [NekoBot] Loading command: {commandName}");
        }
    }
}
