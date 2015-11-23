using Newtonsoft.Json;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGameBan
    {
        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
    }
}