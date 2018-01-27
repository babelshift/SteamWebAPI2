using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class CurrentPlayersResult
    {
        [JsonProperty("player_count")]
        public uint PlayerCount { get; set; }

        [JsonProperty("result")]
        public uint Result { get; set; }
    }

    internal class CurrentPlayersResultContainer
    {
        [JsonProperty("response")]
        public CurrentPlayersResult Result { get; set; }
    }
}