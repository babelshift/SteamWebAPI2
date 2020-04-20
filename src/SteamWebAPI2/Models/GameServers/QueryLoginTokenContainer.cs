using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameServers
{
    public class QueryLoginTokenContainer
    {
        [JsonProperty("response")]
        public QueryLoginTokenResponse Response { get; set; }
    }

    public class QueryLoginTokenResponse
    {
        [JsonProperty("is_banned")]
        public bool IsBanned { get; set; }

        [JsonProperty("expires")]
        public uint Expires { get; set; }

        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }
    }
}