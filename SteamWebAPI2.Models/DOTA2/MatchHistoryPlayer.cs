using Newtonsoft.Json;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchHistoryPlayer
    {
        [JsonProperty(PropertyName = "account_id")]
        public object AccountId { get; set; }

        [JsonProperty(PropertyName = "player_slot")]
        public int PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
    }
}