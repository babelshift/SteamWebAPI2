using Newtonsoft.Json;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchPickBan
    {
        [JsonProperty(PropertyName = "is_pick")]
        public bool IsPick { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        public int Team { get; set; }
        public int Order { get; set; }
    }
}