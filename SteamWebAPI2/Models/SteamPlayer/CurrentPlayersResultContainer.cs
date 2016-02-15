using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class CurrentPlayersResult
    {
        [JsonProperty("player_count")]
        public int PlayerCount { get; set; }

        [JsonProperty("result")]
        public int Result { get; set; }
    }

    internal class CurrentPlayersResultContainer
    {
        [JsonProperty("response")]
        public CurrentPlayersResult Result { get; set; }
    }
}