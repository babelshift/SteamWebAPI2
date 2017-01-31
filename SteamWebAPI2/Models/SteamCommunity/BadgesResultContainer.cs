using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamCommunity
{
    internal class Badge
    {
        [JsonProperty("badgeid")]
        public uint BadgeId { get; set; }

        [JsonProperty("level")]
        public uint Level { get; set; }

        [JsonProperty("completion_time")]
        public uint CompletionTime { get; set; }

        [JsonProperty("xp")]
        public uint Xp { get; set; }

        [JsonProperty("scarcity")]
        public uint Scarcity { get; set; }

        [JsonProperty("appid")]
        public uint? AppId { get; set; }

        [JsonProperty("communityitemid")]
        public string CommunityItemId { get; set; }

        [JsonProperty("border_color")]
        public int? BorderColor { get; set; }
    }

    internal class BadgesResult
    {
        [JsonProperty("badges")]
        public IList<Badge> Badges { get; set; }

        [JsonProperty("player_xp")]
        public uint PlayerXp { get; set; }

        [JsonProperty("player_level")]
        public uint PlayerLevel { get; set; }

        [JsonProperty("player_xp_needed_to_level_up")]
        public uint PlayerXpNeededToLevelUp { get; set; }

        [JsonProperty("player_xp_needed_current_level")]
        public uint PlayerXpNeededCurrentLevel { get; set; }
    }

    internal class BadgesResultContainer
    {
        [JsonProperty("response")]
        public BadgesResult Result { get; set; }
    }
}