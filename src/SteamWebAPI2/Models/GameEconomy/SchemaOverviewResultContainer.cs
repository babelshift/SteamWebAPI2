using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.GameEconomy
{
    public class SchemaOverviewResult
    {
        [JsonProperty("status")]
        public uint Status { get; set; }

        [JsonProperty("items_game_url")]
        public string ItemsGameUrl { get; set; }

        [JsonProperty("qualities")]
        public SchemaQualities Qualities { get; set; }

        [JsonProperty("originNames")]
        public IList<SchemaOriginName> OriginNames { get; set; }

        [JsonProperty("attributes")]
        public IList<SchemaAttribute> Attributes { get; set; }

        [JsonProperty("item_sets")]
        public IList<SchemaItemSet> ItemSets { get; set; }

        [JsonProperty("attribute_controlled_attached_particles")]
        public IList<SchemaAttributeControlledAttachedParticle> AttributeControlledAttachedParticles { get; set; }

        [JsonProperty("item_levels")]
        public IList<SchemaItemLevel> ItemLevels { get; set; }

        [JsonProperty("kill_eater_score_types")]
        public IList<SchemaKillEaterScoreType> KillEaterScoreTypes { get; set; }

        [JsonProperty("string_lookups")]
        public IList<SchemaStringLookup> StringLookups { get; set; }
    }

    public class SchemaOverviewResultContainer
    {
        [JsonProperty("result")]
        public SchemaOverviewResult Result { get; set; }
    }
}