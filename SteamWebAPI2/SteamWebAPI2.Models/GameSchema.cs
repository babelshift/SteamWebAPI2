using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class GameSchema
    {
        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public IList<AchievementSchema> Achievements { get; set; }

        public GameSchema()
        {
            Achievements = new List<AchievementSchema>();
        }
    }

    public class AchievementSchema
    {
        public string Name { get; set; }
        public int DefaultValue { get; set; }
        public string DisplayName { get; set; }
        public bool IsHidden { get; set; }
        public Uri Icon { get; set; }
        public Uri IconGray { get; set; }
    }
}
