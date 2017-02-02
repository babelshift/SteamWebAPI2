using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class ProPlayerInfo
    {
        [JsonProperty(PropertyName = "account_id")]
        public uint AccountId { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "fantasy_role")]
        public uint FantasyRole { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public uint TeamId { get; set; }

        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "team_tag")]
        public string TeamTag { get; set; }

        [JsonProperty(PropertyName = "is_pro")]
        public bool IsPro { get; set; }

        public string Sponsor { get; set; }
    }

    internal class ProPlayerLeaderboard
    {
        public uint Division { get; set; }

        [JsonProperty(PropertyName = "account_ids")]
        public IList<uint> AccountIds { get; set; }
    }

    internal class ProPlayerListResult
    {
        [JsonProperty(PropertyName = "player_infos")]
        public IList<ProPlayerInfo> ProPlayers { get; set; }

        public IList<ProPlayerLeaderboard> Leaderboards { get; set; }
    }
}