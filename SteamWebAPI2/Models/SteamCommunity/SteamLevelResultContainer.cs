using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamCommunity
{
    internal class SteamLevelResult
    {
        [JsonProperty("player_level")]
        public int PlayerLevel { get; set; }
    }

    internal class SteamLevelResultContainer
    {
        [JsonProperty("response")]
        public SteamLevelResult Result { get; set; }
    }
}