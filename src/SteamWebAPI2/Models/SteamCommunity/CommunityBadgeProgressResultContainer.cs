using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamCommunity
{
    internal class BadgeQuest
    {
        [JsonProperty("questid")]
        public uint QuestId { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }

    internal class CommunityBadgeProgressResult
    {
        [JsonProperty("quests")]
        public IList<BadgeQuest> Quests { get; set; }
    }

    internal class CommunityBadgeProgressResultContainer
    {
        [JsonProperty("response")]
        public CommunityBadgeProgressResult Result { get; set; }
    }
}