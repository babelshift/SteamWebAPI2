using System;
using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class TradeOfferModel
    {
        /// <summary>
        /// A unique identifier for the trade offer
        /// </summary>
        public uint TradeOfferId { get; set; }

        /// <summary>
        /// Your partner in the trade offer
        /// </summary>
        public ulong TradePartnerSteamId { get; set; }

        /// <summary>
        /// A message included by the creator of the trade offer
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Unix time when the offer will expire (or expired, if it is in the past)
        /// </summary>
        public DateTime TimeExpiration { get; set; }

        /// <summary>
        /// State of the Trade Offer
        /// </summary>
        public TradeOfferState TradeOfferState { get; set; }

        /// <summary>
        /// Array of CEcon_Asset, items you will give up in the trade (regardless of who created the offer)
        /// </summary>
        public IList<TradeAssetModel> ItemsYouWillGive { get; set; }

        /// <summary>
        /// Array of CEcon_Asset, items you will receive in the trade (regardless of who created the offer)
        /// </summary>
        public IList<TradeAssetModel> ItemsYouWillReceive { get; set; }

        /// <summary>
        /// Boolean to indicate this is an offer you created.
        /// </summary>
        public bool IsOfferYouCreated { get; set; }

        /// <summary>
        /// Unix timestamp of the time the offer was sent
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Unix timestamp of the time the trade_offer_state last changed.
        /// </summary>
        public DateTime TimeUpdated { get; set; }

        /// <summary>
        /// Boolean to indicate this is an offer automatically created from a real-time trade.
        /// </summary>
        public bool WasCreatedFromRealTimeTrade { get; set; }

        /// <summary>
        /// Unix timestamp of when the trade hold period is supposed to be over for this trade offer
        /// </summary>
        public DateTime TimeEscrowEnds { get; set; }

        /// <summary>
        /// The confirmation method that applies to the user asking about the offer.
        /// </summary>
        public TradeOfferConfirmationMethod ConfirmationMethod { get; set; }
    }
}