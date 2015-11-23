using Newtonsoft.Json;

namespace SteamWebAPI2.Models.DOTA2
{
    public class PrizePoolResult
    {
        [JsonProperty(PropertyName = "prize_pool")]
        public int PrizePool { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }

        public int Status { get; set; }
    }
}