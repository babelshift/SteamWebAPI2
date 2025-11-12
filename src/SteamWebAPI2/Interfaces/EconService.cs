using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class EconService : IEconService
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public EconService(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
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

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new TradeHistoryModel
                {
                    TotalTradeCount = result.TotalTradeCount,
                    AreMoreAvailable = result.AreMoreAvailable,
                    Trades = result.Trades?.Select(t => new TradeModel
                    {
                        TradeId = t.TradeId,
                        TradeParterSteamId = t.TradeParterSteamId,
                        TimeTradeStarted = t.TimeTradeStarted.ToDateTime(),
                        TimeEscrowEnds = t.TimeEscrowEnds.ToDateTime(),
                        TradeStatus = (Steam.Models.SteamEconomy.TradeStatus)t.TradeStatus,
                        AssetsReceived = t.AssetsReceived?.Select(a => MapToTradedAssetModel(a)).ToList(),
                        AssetsGiven = t.AssetsGiven?.Select(a => MapToTradedAssetModel(a)).ToList(),
                        CurrencyReceived = t.CurrencyReceived?.Select(a => MapToTradedCurrencyModel(a)).ToList(),
                        CurrencyGiven = t.CurrencyGiven?.Select(a => MapToTradedCurrencyModel(a)).ToList()
                    }).ToList(),
                    Descriptions = result.Descriptions?.ToList()
                };
            });
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

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new TradeOffersResultModel
                {
                    TradeOffersSent = result.TradeOffersSent?.Select(tos => MapToTradeOfferModel(tos)).ToList(),
                    TradeOffersReceived = result.TradeOffersReceived?.Select(tos => MapToTradeOfferModel(tos)).ToList(),
                    Descriptions = result.Descriptions == null ? null : result.Descriptions.ToList()
                };
            });
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

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new TradeOfferResultModel
                {
                    TradeOffer = result.TradeOffer == null ? null : new TradeOfferModel
                    {
                        TradeOfferId = result.TradeOffer.TradeOfferId,
                        TradePartnerSteamId = result.TradeOffer.TradePartnerSteamId,
                        Message = result.TradeOffer.Message,
                        TimeExpiration = result.TradeOffer.TimeExpiration.ToDateTime(),
                        TradeOfferState = (Steam.Models.SteamEconomy.TradeOfferState)result.TradeOffer.TradeOfferState,
                        ItemsYouWillGive = result.TradeOffer.ItemsYouWillGive?.Select(i => MapToTradeAssetModel(i)).ToList(),
                        ItemsYouWillReceive = result.TradeOffer.ItemsYouWillReceive?.Select(i => MapToTradeAssetModel(i)).ToList(),
                        IsOfferYouCreated = result.TradeOffer.IsOfferYouCreated,
                        TimeCreated = result.TradeOffer.TimeCreated.ToDateTime(),
                        TimeUpdated = result.TradeOffer.TimeUpdated.ToDateTime(),
                        WasCreatedFromRealTimeTrade = result.TradeOffer.WasCreatedFromRealTimeTrade,
                        ConfirmationMethod = (Steam.Models.SteamEconomy.TradeOfferConfirmationMethod)result.TradeOffer.ConfirmationMethod,
                        TimeEscrowEnds = result.TradeOffer.TimeEscrowEnds.ToDateTime()
                    },
                    Descriptions = result.Descriptions == null ? null : result.Descriptions.ToList()
                };
            });
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

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new TradeHoldDurationsResultModel
                {
                    MyEscrow = MapToTradeHoldDurationsModel(result.MyEscrow),
                    TheirEscrow = MapToTradeHoldDurationsModel(result.TheirEscrow),
                    BothEscrow = MapToTradeHoldDurationsModel(result.BothEscrow)
                };
            });
        }

        private static TradedAssetModel MapToTradedAssetModel(TradedAsset ta)
        {
            return new TradedAssetModel
            {
                AppId = ta.AppId,
                ContextId = ta.ContextId,
                AssetId = ta.AssetId,
                AmountTraded = ta.AmountTraded,
                ClassId = ta.ClassId,
                InstanceId = ta.InstanceId,
                AssetIdAfterTrade = ta.AssetIdAfterTrade,
                ContextIdAfterTrade = ta.ContextIdAfterTrade,
                AssetIdAfterRollback = ta.AssetIdAfterRollback,
                ContextIdAfterRollback = ta.ContextIdAfterRollback
            };
        }

        private static TradedCurrencyModel MapToTradedCurrencyModel(TradedCurrency tc)
        {
            return new TradedCurrencyModel
            {
                AppId = tc.AppId,
                ContextId = tc.ContextId,
                CurrencyId = tc.CurrencyId,
                AmountTraded = tc.AmountTraded,
                ClassId = tc.ClassId,
                CurrencyIdAfterTrade = tc.CurrencyIdAfterTrade,
                ContextIdAfterTrade = tc.ContextIdAfterTrade,
                CurrencyIdAfterRollback = tc.CurrencyIdAfterRollback,
                ContextIdAfterRollback = tc.ContextIdAfterRollback
            };
        }

        private static TradeOfferModel MapToTradeOfferModel(TradeOffer to)
        {
            return new TradeOfferModel
            {
                TradeOfferId = to.TradeOfferId,
                TradePartnerSteamId = to.TradePartnerSteamId,
                Message = to.Message,
                TimeExpiration = to.TimeExpiration.ToDateTime(),
                TradeOfferState = (Steam.Models.SteamEconomy.TradeOfferState)to.TradeOfferState,
                ItemsYouWillGive = to.ItemsYouWillGive?.Select(i => MapToTradeAssetModel(i)).ToList(),
                ItemsYouWillReceive = to.ItemsYouWillReceive?.Select(i => MapToTradeAssetModel(i)).ToList(),
                IsOfferYouCreated = to.IsOfferYouCreated,
                TimeCreated = to.TimeCreated.ToDateTime(),
                TimeUpdated = to.TimeUpdated.ToDateTime(),
                WasCreatedFromRealTimeTrade = to.WasCreatedFromRealTimeTrade,
                ConfirmationMethod = (Steam.Models.SteamEconomy.TradeOfferConfirmationMethod)to.ConfirmationMethod,
                TimeEscrowEnds = to.TimeEscrowEnds.ToDateTime()
            };
        }

        private static TradeAssetModel MapToTradeAssetModel(TradeAsset ta)
        {
            return new TradeAssetModel
            {
                AppId = ta.AppId,
                ContextId = ta.ContextId,
                AssetId = ta.AssetId,
                AmountOffered = ta.AmountOffered,
                ClassId = ta.ClassId,
                InstanceId = ta.InstanceId,
                CurrencyId = ta.CurrencyId,
                IsMissing = ta.IsMissing
            };
        }

        private static TradeHoldDurationsModel MapToTradeHoldDurationsModel(TradeHoldDurations d)
        {
            return new TradeHoldDurationsModel
            {
                EscrowEndDuration = TimeSpan.FromSeconds(d.EscrowEndDurationSeconds),
                EscrowEndDate = d.EscrowEndDateRfc3339,
            };
        }

    }
}