using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class TradeOffersResult
    {
        [JsonProperty("trade_offers_sent")]
        public IList<TradeOffer> TradeOffersSent { get; set; }
        [JsonProperty("trade_offers_received")]
        public IList<TradeOffer> TradeOffersReceived { get; set; }
        [JsonProperty("descriptions")]
        public IList<string> Descriptions { get; set; }
    }

    internal class TradeOffersResultContainer
    {
        [JsonProperty("response")]
        public TradeOffersResult Result { get; set; }
    }
}
