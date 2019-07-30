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
            NekoBot bot = new NekoBot();

            await bot.RunAsync();

            await Task.Delay(-1);
        }
    }
}
