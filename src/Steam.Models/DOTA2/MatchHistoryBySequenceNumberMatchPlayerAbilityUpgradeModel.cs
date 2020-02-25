using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.DOTA2
{
    public class MatchHistoryBySequenceNumberMatchPlayerAbilityUpgradeModel
    {
        public uint Ability { get; set; }
        
        public uint Time { get; set; }
        
        public uint Level { get; set; }
    }
}
