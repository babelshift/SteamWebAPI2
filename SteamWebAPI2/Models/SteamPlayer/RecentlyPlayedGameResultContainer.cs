using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class RecentlyPlayedGame
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playtime_2weeks")]
        public uint Playtime2Weeks { get; set; }

        [JsonProperty("playtime_forever")]
        public uint PlaytimeForever { get; set; }

        [JsonProperty("img_icon_url")]
        public string ImgIconUrl { get; set; }

        [JsonProperty("img_logo_url")]
        public string ImgLogoUrl { get; set; }
    }

    internal class RecentlyPlayedGameResult
    {
        [JsonProperty("total_count")]
        public uint TotalCount { get; set; }

        [JsonProperty("games")]
        public IList<RecentlyPlayedGame> RecentlyPlayedGames { get; set; }
    }

    internal class RecentlyPlayedGameResultContainer
    {
        [JsonProperty("response")]
        public RecentlyPlayedGameResult Result { get; set; }
    }
}