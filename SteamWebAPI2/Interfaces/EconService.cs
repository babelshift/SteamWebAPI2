using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class EconService : IEconService
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public EconService(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "IEconService")
                : steamWebInterface;
        }

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
        public async Task<ISteamWebResponse<Steam.Models.SteamEconomy.TradeHistoryModel>> GetTradeHistoryAsync(uint maxTrades, uint startAfterTime = 0, ulong startAfterTradeId = 0, bool navigatingBack = false, bool getDescriptions = false, string language = "", bool includeFailed = false, bool includeTotal = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(maxTrades, "max_trades");
            parameters.AddIfHasValue(startAfterTime, "start_after_time");
            parameters.AddIfHasValue(startAfterTradeId, "start_after_tradeid");
            parameters.AddIfHasValue(navigatingBack, "navigating_back");
            parameters.AddIfHasValue(getDescriptions, "get_descriptions");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(includeFailed, "include_failed");
            parameters.AddIfHasValue(includeTotal, "inclue_total");

            var steamWebResponse = await steamWebInterface.GetAsync<TradeHistoryResultContainer>("GetTradeHistory", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<TradeHistoryResultContainer>, 
                ISteamWebResponse<Steam.Models.SteamEconomy.TradeHistoryModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

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
        public async Task<ISteamWebResponse<Steam.Models.SteamEconomy.TradeOffersResultModel>> GetTradeOffersAsync(bool getSentOffers, bool getReceivedOffers, bool getDescriptions = false, string language = "", bool activeOnly = false, bool historicalOnly = false, uint timeHistoricalCutoff = 0)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int getSentOffersBit = getSentOffers ? 1 : 0;
            int getReceivedOffersBit = getReceivedOffers ? 1 : 0;

            parameters.AddIfHasValue(getSentOffersBit, "get_sent_offers");
            parameters.AddIfHasValue(getReceivedOffersBit, "get_received_offers");
            parameters.AddIfHasValue(getDescriptions, "get_descriptions");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(activeOnly, "active_only");
            parameters.AddIfHasValue(historicalOnly, "historicalOnly");
            parameters.AddIfHasValue(timeHistoricalCutoff, "time_historical_cutoff");

            var steamWebResponse = await steamWebInterface.GetAsync<TradeOffersResultContainer>("GetTradeOffers", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<TradeOffersResultContainer>, 
                ISteamWebResponse<Steam.Models.SteamEconomy.TradeOffersResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// This API gets details about a single trade offer. The trade offer must have been sent to or from the account associated with the WebAPI key. You cannot call this API for accounts other than your own.
        /// </summary>
        /// <param name="tradeOfferId">The trade offer identifier</param>
        /// <param name="language">The language to use for item display information.</param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<Steam.Models.SteamEconomy.TradeOfferResultModel>> GetTradeOfferAsync(ulong tradeOfferId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(tradeOfferId, "tradeOfferId");
            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<TradeOfferResultContainer>("GetTradeOffer", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<TradeOfferResultContainer>, 
                ISteamWebResponse<Steam.Models.SteamEconomy.TradeOfferResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}