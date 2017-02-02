using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class DeclineTradeOfferResult
    {
        // ??
    }

    internal class DeclineTradeOfferResultContainer
    {
        [JsonProperty("response")]
        public DeclineTradeOfferResult Result { get; set; }
    }
}
