using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class CancelTradeOfferResult
    {
        // ?? TBD?
    }

    internal class CancelTradeOfferResultContainer
    {
        [JsonProperty("response")]
        public CancelTradeOfferResult Result { get; set; }
    }
}