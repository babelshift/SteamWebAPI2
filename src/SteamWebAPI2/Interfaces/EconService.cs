using AutoMapper;
using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class EconService : IEconService
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public EconService(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IEconService", steamWebRequest)
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
        public async Task<ISteamWebResponse<TradeHistoryModel>> GetTradeHistoryAsync(
            uint maxTrades,
            DateTime? startAfterTime = null,
            ulong startAfterTradeId = 0,
            bool navigatingBack = false,
            bool getDescriptions = false,
            string language = "",
            bool includeFailed = false,
            bool includeTotal = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            ulong? startAfterTimeUnix = startAfterTime.HasValue 
                ? startAfterTime.Value.ToUnixTimeStamp() 
                : (ulong?)null;

            parameters.AddIfHasValue(maxTrades, "max_trades");
            parameters.AddIfHasValue(startAfterTimeUnix, "start_after_time");
            parameters.AddIfHasValue(startAfterTradeId, "start_after_tradeid");
            parameters.AddIfHasValue(navigatingBack, "navigating_back");
            parameters.AddIfHasValue(getDescriptions, "get_descriptions");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(includeFailed, "include_failed");
            parameters.AddIfHasValue(includeTotal, "include_total");

            var steamWebResponse = await steamWebInterface.GetAsync<TradeHistoryResultContainer>("GetTradeHistory", 1, parameters);

            var steamWebResponseModel = mapper.Map<
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
        public async Task<ISteamWebResponse<TradeOffersResultModel>> GetTradeOffersAsync(
            bool getSentOffers,
            bool getReceivedOffers,
            bool getDescriptions = false,
            string language = "",
            bool activeOnly = false,
            bool historicalOnly = false,
            DateTime? timeHistoricalCutoff = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int getSentOffersBit = getSentOffers ? 1 : 0;
            int getReceivedOffersBit = getReceivedOffers ? 1 : 0;

            ulong? timeHistoricalCutoffUnix = timeHistoricalCutoff.HasValue 
                ? timeHistoricalCutoff.Value.ToUnixTimeStamp() 
                : (ulong?)null;

            parameters.AddIfHasValue(getSentOffersBit, "get_sent_offers");
            parameters.AddIfHasValue(getReceivedOffersBit, "get_received_offers");
            parameters.AddIfHasValue(getDescriptions, "get_descriptions");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(activeOnly, "active_only");
            parameters.AddIfHasValue(historicalOnly, "historicalOnly");
            parameters.AddIfHasValue(timeHistoricalCutoffUnix, "time_historical_cutoff");

            var steamWebResponse = await steamWebInterface.GetAsync<TradeOffersResultContainer>("GetTradeOffers", 1, parameters);

            var steamWebResponseModel = mapper.Map<
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
        public async Task<ISteamWebResponse<TradeOfferResultModel>> GetTradeOfferAsync(
            ulong tradeOfferId,
            string language = "",
            bool getDescriptions = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(tradeOfferId, "tradeOfferId");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(getDescriptions, "get_descriptions");

            var steamWebResponse = await steamWebInterface.GetAsync<TradeOfferResultContainer>("GetTradeOffer", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<TradeOfferResultContainer>,
                ISteamWebResponse<Steam.Models.SteamEconomy.TradeOfferResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        public async Task<ISteamWebResponse<dynamic>> GetTradeStatusAsync(ulong tradeId, bool getDescriptions, string language)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(tradeId, "tradeid");
            parameters.AddIfHasValue(getDescriptions, "get_descriptions");
            parameters.AddIfHasValue(language, "language");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetTradeStatus", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetTradeOffersSummaryAsync(DateTime? timeLastVisit = null)
        {
            ulong? timeLastVisitUnix = timeLastVisit.HasValue 
                ? timeLastVisit.Value.ToUnixTimeStamp() 
                : (ulong?)null;

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(timeLastVisitUnix, "time_last_visit");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetTradeOffersSummary", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> DeclineTradeOfferAsync(ulong tradeOfferId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(tradeOfferId, "tradeofferid");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("DeclineTradeOffer", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> CancelTradeOfferAsync(ulong tradeOfferId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(tradeOfferId, "tradeofferid");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("CancelTradeOffer", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<TradeHoldDurationsResultModel>> GetTradeHoldDurationsAsync(ulong steamIdTarget, string tradeOfferAccessToken = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamIdTarget, "steamid_target");
            parameters.AddIfHasValue(tradeOfferAccessToken, "trade_offer_access_token");
            var steamWebResponse = await steamWebInterface.GetAsync<TradeHoldDurationsResultContainer>("GetTradeHoldDurations", 1, parameters);
            
            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<TradeHoldDurationsResultContainer>,
                ISteamWebResponse<TradeHoldDurationsResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}