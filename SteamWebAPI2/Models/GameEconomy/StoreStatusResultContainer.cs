using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameEconomy
{
    internal class StoreStatusResult
    {
        [JsonProperty("status")]
        public uint Status { get; set; }

        [JsonProperty("store_status")]
        public uint StoreStatus { get; set; }
    }

    internal class StoreStatusResultContainer
    {
        [JsonProperty("result")]
        public StoreStatusResult Result { get; set; }
    }
}