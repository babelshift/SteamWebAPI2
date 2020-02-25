using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class TradeHistoryModel
    {
        /// <summary>
        /// Total number of trades performed by the account
        /// </summary>
        public uint TotalTradeCount { get; set; }

        /// <summary>
        /// Whether or not more are available
        /// </summary>
        public bool AreMoreAvailable { get; set; }

        /// <summary>
        /// Array of CEcon_GetTradeHistory_Response_Trade
        /// </summary>
        public IList<TradeModel> Trades { get; set; }

        /// <summary>
        /// If get_descriptions was set, this will be a list of item display information. This is associated with the data in the assets/currency_received and assets/currency_given lists via the classid / instanceid identifier pair.
        /// </summary>
        public IList<string> Descriptions { get; set; }
    }
}