using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class UserAchievements
    {
        public long SteamID { get; set; }
        public string GameName { get; set; }
        public IList<GlobalAchievementPercentage> Achievements { get; set; }

        public UserAchievements()
        {
            Achievements = new List<GlobalAchievementPercentage>();
        }
    }
}
