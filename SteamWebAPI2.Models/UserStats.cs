using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class UserStats
    {
        public long SteamID { get; set; }
        public string GameName { get; set; }
        public IList<GlobalAchievementPercentage> Achievements { get; set; }
        public IList<PlayerStat> Stats { get; set; }

        public UserStats()
        {
            Achievements = new List<GlobalAchievementPercentage>();
            Stats = new List<PlayerStat>();
        }
    }

    public class PlayerStat
    {
        public string Name { get; set; }
        public long Value { get; set; }
    }
}
