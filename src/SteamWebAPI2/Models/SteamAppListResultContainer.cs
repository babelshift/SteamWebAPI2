using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models
{
    internal class SteamApp
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    internal class SteamAppListResult
    {
        [JsonProperty("apps")]
        public IList<SteamApp> Apps { get; set; }
    }

    internal class SteamAppListResultContainer
    {
        [JsonProperty("applist")]
        public SteamAppListResult Result { get; set; }
    }
}