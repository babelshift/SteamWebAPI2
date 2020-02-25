using System;
using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class TradeModel
    {
        /// <summary>
        /// A unique identifier for the trade
        /// </summary>
        public ulong TradeId { get; set; }

        /// <summary>
        /// The SteamID of your trade partner
        /// </summary>
        public ulong TradeParterSteamId { get; set; }

        /// <summary>
        /// Unix timestamp of the time the trade started to commit
        /// </summary>
        public DateTime TimeTradeStarted { get; set; }

        /// <summary>
        /// Unix timestamp of the time the trade will leave escrow
        /// </summary>
        public DateTime TimeEscrowEnds { get; set; }

        /// <summary>
        /// Status of the Trade
        /// </summary>
        public TradeStatus TradeStatus { get; set; }

        /// <summary>
        /// Array of CEcon_GetTradeHistory_Response_Trade_TradedAsset showing the items received in the trade
        /// </summary>
        public IList<TradedAssetModel> AssetsReceived { get; set; }

        /// <summary>
        /// Array of CEcon_GetTradeHistory_Response_Trade_TradedAsset showing the items given to the other party in the trade
        /// </summary>
        public IList<TradedAssetModel> AssetsGiven { get; set; }

        /// <summary>
        /// Array of CEcon_GetTradeHistory_Response_Trade_TradedCurrency showing the items received in the trade
        /// </summary>
        public IList<TradedCurrencyModel> CurrencyReceived { get; set; }

        /// <summary>
        /// array of CEcon_GetTradeHistory_Response_Trade_TradedCurrency showing the items given to the other party in the trade
        /// </summary>
        public IList<TradedCurrencyModel> CurrencyGiven { get; set; }
    }
}