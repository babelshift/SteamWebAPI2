using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.DOTA2
{
    public class MatchHistoryBySequenceNumberMatchPlayerModel
    {
        public IList<MatchHistoryBySequenceNumberMatchPlayerAbilityUpgradeModel> AbilityUpgrades { get; set; }
        
        public ulong AccountId { get; set; }
        
        public uint PlayerSlot { get; set; }
        
        public uint HeroId { get; set; }
        
        public uint Item0 { get; set; }
        
        public uint Item1 { get; set; }
        
        public uint Item2 { get; set; }
        
        public uint Item3 { get; set; }
        
        public uint Item4 { get; set; }
        
        public uint Item5 { get; set; }
        
        public uint Kills { get; set; }
        
        public uint Deaths { get; set; }
        
        public uint Assists { get; set; }
        
        public uint LeaverStatus { get; set; }
        
        public uint LastHits { get; set; }
        
        public uint Denies { get; set; }
        
        public uint GoldPerMin { get; set; }
        
        public uint XpPerMin { get; set; }
        
        public uint Level { get; set; }
        
        public uint Gold { get; set; }
        
        public uint GoldSpent { get; set; }
        
        public uint HeroDamage { get; set; }
        
        public uint TowerDamage { get; set; }
        
        public uint HeroHealing { get; set; }
    }
}
