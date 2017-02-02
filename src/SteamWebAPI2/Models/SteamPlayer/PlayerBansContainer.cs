using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamPlayer
{
    internal class PlayerBans
    {
        public string SteamId { get; set; }

        public bool CommunityBanned { get; set; }

        public bool VACBanned { get; set; }

        public uint NumberOfVACBans { get; set; }

        public uint DaysSinceLastBan { get; set; }

        public uint NumberOfGameBans { get; set; }

        public string EconomyBan { get; set; }
    }

    internal class PlayerBansContainer
    {
        [JsonProperty(PropertyName = "players")]
        public IList<PlayerBans> PlayerBans { get; set; }
    }
}