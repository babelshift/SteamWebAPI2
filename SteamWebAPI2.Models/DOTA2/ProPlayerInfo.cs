using Newtonsoft.Json;

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
}