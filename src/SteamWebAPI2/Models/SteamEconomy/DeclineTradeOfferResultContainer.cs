using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class DeclineTradeOfferResult
    {
        // ?? TBD?
    }

    internal class DeclineTradeOfferResultContainer
    {
        [JsonProperty("response")]
        public DeclineTradeOfferResult Result { get; set; }
    }
}