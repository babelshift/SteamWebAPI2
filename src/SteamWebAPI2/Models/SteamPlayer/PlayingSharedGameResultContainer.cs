using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class PlayingSharedGameResult
    {
        [JsonProperty("lender_steamid")]
        public ulong? LenderSteamId { get; set; }
    }

    internal class PlayingSharedGameResultContainer
    {
        [JsonProperty("response")]
        public PlayingSharedGameResult Result { get; set; }
    }
}