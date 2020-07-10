using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.GameEconomy
{
    public class SchemaItemsResult
    {
        [JsonProperty("status")]
        public uint Status { get; set; }

        [JsonProperty("items_game_url")]
        public string ItemsGameUrl { get; set; }

        [JsonProperty("items")]
        public IList<SchemaItem> Items { get; set; }

        [JsonProperty("next")]
        public uint? Next { get; set; }
    }

    public class SchemaItemsResultContainer
    {
        [JsonProperty("result")]
        public SchemaItemsResult Result { get; set; }
    }
}