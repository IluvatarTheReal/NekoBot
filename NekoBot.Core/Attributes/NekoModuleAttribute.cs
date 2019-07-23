using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace NekoBot.Core.Attributes
{
    public class NekoModuleAttribute : GroupAttribute
    {
        public NekoModuleAttribute(string moduleName)
            : base(moduleName)
        {
        }
    }
}
