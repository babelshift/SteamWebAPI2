using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class OwnedGame
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playtime_forever")]
        public uint PlaytimeForever { get; set; }

        [JsonProperty("img_icon_url")]
        public string ImgIconUrl { get; set; }

        [JsonProperty("img_logo_url")]
        public string ImgLogoUrl { get; set; }

        [JsonProperty("has_community_visible_stats")]
        public bool HasCommunityVisibleStats { get; set; }

        [JsonProperty("playtime_2weeks")]
        public uint? Playtime2weeks { get; set; }
    }

    internal class OwnedGamesResult
    {
        [JsonProperty("game_count")]
        public uint GameCount { get; set; }

        [JsonProperty("games")]
        public IList<OwnedGame> OwnedGames { get; set; }
    }

    internal class OwnedGamesResultContainer
    {
        [JsonProperty("response")]
        public OwnedGamesResult Result { get; set; }
    }
}