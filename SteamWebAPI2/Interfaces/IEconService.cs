using Steam.Models.SteamEconomy;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IEconService
    {
        /// <summary>
        /// This API gets a list of trade offers (up to a maximum of 500 sent or 1000 received regardless of time_historical_cutoff) for the account associated with the WebAPI key. You cannot call this API for accounts other than your own.
        /// </summary>
        /// <param name="maxTrades">The number of trades to return information for, limit 500 if get_descriptions is false and 100 if get_descriptions is true</param>
        /// <param name="startAfterTime">The time of the last trade shown on the previous page of results, or the time of the first trade if navigating back</param>
        /// <param name="startAfterTradeId">The tradeid shown on the previous page of results, or the ID of the first trade if navigating back</param>
        /// <param name="navigatingBack">Return the previous max_trades trades before the start time and ID</param>
        /// <param name="getDescriptions">If set, the item display data for the items included in the returned trades will also be returned</param>
        /// <param name="language">The language to use when loading item display data</param>
        /// <param name="includeFailed">If set, trades in status k_ETradeStatus_Failed, k_ETradeStatus_RollbackFailed, k_ETradeStatus_RollbackAbandoned, and k_ETradeStatus_EscrowRollback will be included</param>
        /// <param name="includeTotal">Unknown</param>
        /// <returns></returns>
        Task<ISteamWebResponse<TradeHistoryModel>> GetTradeHistoryAsync(uint maxTrades, uint startAfterTime, ulong startAfterTradeId, bool navigatingBack, bool getDescriptions, string language, bool includeFailed, bool includeTotal);

        /// <summary>
        /// This API gets a list of trade offers (up to a maximum of 500 sent or 1000 received regardless of time_historical_cutoff) for the account associated with the WebAPI key. You cannot call this API for accounts other than your own.
        /// </summary>
        /// <param name="getSentOffers">Return the list of offers you've sent to other people.</param>
        /// <param name="getReceivedOffers">Return the list of offers you've received from other people.</param>
        /// <param name="getDescriptions">Return item display information for any items included in the returned offers.</param>
        /// <param name="language">Needed if get_descriptions is set, the language to use for item descriptions.</param>
        /// <param name="activeOnly">Return only trade offers in an active state (offers that haven't been accepted yet), or any offers that have had their state change since time_historical_cutoff.</param>
        /// <param name="historicalOnly">Return trade offers that are not in an active state.</param>
        /// <param name="timeHistoricalCutoff">A unix time value. when active_only is set, inactive offers will be returned if their state was updated since this time. Useful to get delta updates on what has changed. WARNING: If not passed, this will default to the time your account last viewed the trade offers page. To avoid this behavior use a very low or very high date.</param>
        /// <returns></returns>
        Task<ISteamWebResponse<TradeOffersResultModel>> GetTradeOffersAsync(bool getSentOffers, bool getReceivedOffers, bool getDescriptions, string language, bool activeOnly, bool historicalOnly, uint timeHistoricalCutoff);

        /// <summary>
        /// This API gets details about a single trade offer. The trade offer must have been sent to or from the account associated with the WebAPI key. You cannot call this API for accounts other than your own.
        /// </summary>
        /// <param name="tradeOfferId">The trade offer identifier</param>
        /// <param name="language">The language to use for item display information.</param>
        /// <returns></returns>
        Task<ISteamWebResponse<TradeOfferResultModel>> GetTradeOfferAsync(ulong tradeOfferId, string language);

        //Task GetTradeOffersSummary(ulong timeLastVisit);
        //Task DeclineTradeOffer(ulong tradeOfferId);
        //Task CancelTradeOffer(ulong tradeOfferId);
    }
}