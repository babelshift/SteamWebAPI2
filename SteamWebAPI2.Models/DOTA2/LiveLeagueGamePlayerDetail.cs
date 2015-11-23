using Newtonsoft.Json;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGamePlayerDetail
    {
        [JsonProperty(PropertyName = "player_slot")]
        public int PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        public int Kills { get; set; }

        [JsonProperty(PropertyName = "death")]
        public int Deaths { get; set; }

        public int Assists { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }

        public int Denies { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public int GoldPerMinute { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public int ExperiencePerMinute { get; set; }

        [JsonProperty(PropertyName = "ultimate_state")]
        public int UltimateState { get; set; }

        [JsonProperty(PropertyName = "ultimate_cooldown")]
        public int UltimateCooldown { get; set; }

        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }

        [JsonProperty(PropertyName = "respawn_timer")]
        public int RespawnTimer { get; set; }

        [JsonProperty(PropertyName = "position_x")]
        public double PositionX { get; set; }

        [JsonProperty(PropertyName = "position_y")]
        public double PositionY { get; set; }

        [JsonProperty(PropertyName = "net_worth")]
        public int NetWorth { get; set; }
    }
}