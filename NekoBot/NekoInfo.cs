using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NekoBot
{
    public class NekoInfo
    {
        public static string Version { get { return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion; } }
        public static string Author { get { return "Iluvatar / Samuel Reid"; } } //If you change this, please leave credit at least, I'd be grateful!
        public static string GitRepository { get { return @"https://github.com/IluvatarTheReal/NekoBot"; } }
    }
}
