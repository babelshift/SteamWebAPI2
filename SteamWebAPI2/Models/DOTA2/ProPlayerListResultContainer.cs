using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class ProPlayerInfo
    {
        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "fantasy_role")]
        public int FantasyRole { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "team_tag")]
        public string TeamTag { get; set; }

        [JsonProperty(PropertyName = "is_pro")]
        public bool IsPro { get; set; }

        public string Sponsor { get; set; }
    }

    public class ProPlayerLeaderboard
    {
        public int Division { get; set; }

        [JsonProperty(PropertyName = "account_ids")]
        public IList<int> AccountIds { get; set; }
    }

    public class ProPlayerListResult
    {
        [JsonProperty(PropertyName = "player_infos")]
        public IList<ProPlayerInfo> PlayerInfos { get; set; }

        public IList<ProPlayerLeaderboard> Leaderboards { get; set; }
    }

    internal class ProPlayerListResultContainer
    {
        [JsonProperty(PropertyName = "results")]
        public ProPlayerListResult Result { get; set; }
    }
}