using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamCommunity
{
    internal class ResolveVanityUrlResult
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }

        [JsonProperty("success")]
        public uint Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    internal class ResolveVanityUrlResultContainer
    {
        [JsonProperty("response")]
        public ResolveVanityUrlResult Result { get; set; }
    }
}