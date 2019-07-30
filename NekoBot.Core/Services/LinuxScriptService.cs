using Discord.WebSocket;
using NekoBot.Core.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NekoBot.Core.Services
{
    public class LinuxScriptService : NekoServiceBase
    {
        protected LinuxScriptService(DiscordSocketClient _client)
            : base(_client)
        {
            
        }

        


    }

    public static class ShellHelper
    {
        public static string Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }

}
