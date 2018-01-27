using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.TF2
{
    internal class GoldenWrench
    {
        [JsonProperty("steamID")]
        public object SteamId { get; set; }

        [JsonConverter(typeof(UnixTimeJsonConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("itemID")]
        public uint ItemId { get; set; }

        [JsonProperty("wrenchNumber")]
        public uint WrenchNumber { get; set; }
    }

    internal class GoldenWrenchResult
    {
        [JsonProperty("wrenches")]
        public IList<GoldenWrench> GoldenWrenches { get; set; }
    }

    internal class GoldenWrenchResultContainer
    {
        [JsonProperty("results")]
        public GoldenWrenchResult Result { get; set; }
    }
}