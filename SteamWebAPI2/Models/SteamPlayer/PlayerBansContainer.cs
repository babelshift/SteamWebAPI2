using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class PlayerBans
    {
        public string SteamId { get; set; }

        public bool CommunityBanned { get; set; }

        public bool VACBanned { get; set; }

        public int NumberOfVACBans { get; set; }

        public int DaysSinceLastBan { get; set; }

        public int NumberOfGameBans { get; set; }

        public string EconomyBan { get; set; }
    }

    internal class PlayerBansContainer
    {
        [JsonProperty(PropertyName = "players")]
        public IList<PlayerBans> PlayerBans { get; set; }
    }
}