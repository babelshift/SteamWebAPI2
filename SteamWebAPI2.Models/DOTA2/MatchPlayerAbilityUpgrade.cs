using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchPlayerAbilityUpgrade
    {
        public int Ability { get; set; }
        public int Time { get; set; }
        public int Level { get; set; }
    }
}
