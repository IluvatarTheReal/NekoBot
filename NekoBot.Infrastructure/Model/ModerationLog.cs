using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace NekoBot.Infrastructure.Model
{
    public class ModerationLog : EntityBase
    {        
        public enum ModAction { Kick, Ban, Unban }


        public ModAction Action { get; set; }
        public string Reason { get; set; }
        public DateTime Timestamp { get; set; }
        public ulong TargetedUserId { get; set; }
        public string TargetUsername { get; set; }
        public ulong ExecutingUserId { get; set; }
        public string ExecutingUsername { get; set; }

    }
}
