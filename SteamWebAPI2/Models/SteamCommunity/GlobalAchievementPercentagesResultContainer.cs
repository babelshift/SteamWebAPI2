using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamCommunity
{
    internal class GlobalAchievementPercentage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }
    }

    internal class GlobalAchievementPercentagesResult
    {
        [JsonProperty("achievements")]
        public IList<GlobalAchievementPercentage> AchievementPercentages { get; set; }
    }

    internal class GlobalAchievementPercentagesResultContainer
    {
        [JsonProperty("achievementpercentages")]
        public GlobalAchievementPercentagesResult Result { get; set; }
    }
}