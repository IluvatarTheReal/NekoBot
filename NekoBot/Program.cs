using System;
using System.Threading.Tasks;
using NekoBot.Core;

namespace NekoBot
{
    class Program
    {
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            NekoBot bot = new NekoBot("MjI1ODA0NzQ5MjMwODMzNjY0.XTJgGQ.AdFWBL6Jm9Ii8h-wkzdVIZYyiaE");

            await bot.RunAsync();

            await Task.Delay(-1);
        }
    }
}
