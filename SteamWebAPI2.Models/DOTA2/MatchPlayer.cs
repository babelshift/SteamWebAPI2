using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchPlayer
    {
        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }
        [JsonProperty(PropertyName = "player_slot")]
        public int PlayerSlot { get; set; }
        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
        [JsonProperty(PropertyName = "item_0")]
        public int Item0 { get; set; }
        [JsonProperty(PropertyName = "item_1")]
        public int Item1 { get; set; }
        [JsonProperty(PropertyName = "item_2")]
        public int Item2 { get; set; }
        [JsonProperty(PropertyName = "item_3")]
        public int Item3 { get; set; }
        [JsonProperty(PropertyName = "item_4")]
        public int Item4 { get; set; }
        [JsonProperty(PropertyName = "item_5")]
        public int Item5 { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        [JsonProperty(PropertyName = "leaver_status")]
        public int LeaverStatus { get; set; }
        public int Gold { get; set; }
        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }
        public int Denies { get; set; }
        [JsonProperty(PropertyName = "gold_per_min")]
        public int GoldPerMinute { get; set; }
        [JsonProperty(PropertyName = "xp_per_min")]
        public int ExperiencePerMinute { get; set; }
        [JsonProperty(PropertyName = "gold_spent")]
        public int GoldSpent { get; set; }
        [JsonProperty(PropertyName = "hero_damage")]
        public int HeroDamage { get; set; }
        [JsonProperty(PropertyName = "tower_damage")]
        public int TowerDamage { get; set; }
        [JsonProperty(PropertyName = "hero_healing")]
        public int HeroHealing { get; set; }
        public int Level { get; set; }
        [JsonProperty(PropertyName = "ability_upgrades")]
        public IList<MatchPlayerAbilityUpgrade> AbilityUpgrades { get; set; }
    }
}
