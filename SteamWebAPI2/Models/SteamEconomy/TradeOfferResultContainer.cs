using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class TradeOfferResult
    {
        [JsonProperty("offer")]
        public TradeOffer TradeOffer { get; set; }
        [JsonProperty("descriptions")]
        public IList<string> Descriptions { get; set; }
    }

    internal class TradeOfferResultContainer
    {
        [JsonProperty("response")]
        public TradeOfferResult Result { get; set; }
    }
}
