using Newtonsoft.Json;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class PrizePoolResult
    {
        [JsonProperty(PropertyName = "prize_pool")]
        public int PrizePool { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }

        public int Status { get; set; }
    }

    internal class PrizePoolResultContainer
    {
        public PrizePoolResult Result { get; set; }
    }
}