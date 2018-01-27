using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class TradeOffer
    {
        [JsonProperty("tradeofferid")]
        public uint TradeOfferId { get; set; }

        [JsonProperty("accountid_other")]
        public ulong TradePartnerSteamId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("expiration_time")]
        public ulong TimeExpiration { get; set; }

        [JsonProperty("trade_offer_state")]
        public TradeOfferState TradeOfferState { get; set; }

        [JsonProperty("items_to_give")]
        public IList<TradeAsset> ItemsYouWillGive { get; set; }

        [JsonProperty("items_to_receive")]
        public IList<TradeAsset> ItemsYouWillReceive { get; set; }

        [JsonProperty("is_our_offer")]
        public bool IsOfferYouCreated { get; set; }

        [JsonProperty("time_created")]
        public ulong TimeCreated { get; set; }

        [JsonProperty("time_updated")]
        public ulong TimeUpdated { get; set; }

        [JsonProperty("from_real_time_trade")]
        public bool WasCreatedFromRealTimeTrade { get; set; }

        [JsonProperty("escrow_end_date")]
        public ulong TimeEscrowEnds { get; set; }

        [JsonProperty("confirmation_method")]
        public TradeOfferConfirmationMethod ConfirmationMethod { get; set; }
    }
}