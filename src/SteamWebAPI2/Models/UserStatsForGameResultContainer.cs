using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models
{
    internal class UserStat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    internal class UserStatAchievement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("achieved")]
        public uint Achieved { get; set; }
    }

    internal class UserStatsForGameResult
    {
        [JsonProperty("steamID")]
        public string SteamId { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("stats")]
        public IList<UserStat> Stats { get; set; }

        [JsonProperty("achievements")]
        public IList<UserStatAchievement> Achievements { get; set; }
    }

    internal class UserStatsForGameResultContainer
    {
        [JsonProperty("playerstats")]
        public UserStatsForGameResult Result { get; set; }
    }
}