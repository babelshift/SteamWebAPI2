using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class PlayerAchievement
    {
        [JsonProperty("apiname")]
        public string APIName { get; set; }

        [JsonProperty("achieved")]
        public uint Achieved { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    internal class PlayerAchievementResult
    {
        [JsonProperty("steamID")]
        public ulong SteamId { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("achievements")]
        public IList<PlayerAchievement> Achievements { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }

    internal class PlayerAchievementResultContainer
    {
        [JsonProperty("playerstats")]
        public PlayerAchievementResult Result { get; set; }
    }
}