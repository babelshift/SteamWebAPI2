using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal enum TradeOfferState
    {
        Invalid = 1,
        Active = 2,
        Accepted = 3,
        Countered = 4,
        Expired = 5,
        Canceled = 6,
        Declined = 7,
        InvalidItems = 8,
        CreateNeedsConfirmation = 9,
        CanceledBySecondFactor = 10,
        InEscrow = 11
    }

    internal enum TradeOfferConfirmationMethod
    {
        Invalid = 0,
        Email = 1,
        MobileApp = 2
    }

    internal enum TradeStatus
    {
        Init = 0,
        PreCommitted = 1,
        Committed = 2,
        Complete = 3,
        Failed = 4,
        PartialSupportRollback = 5,
        FullSupportRollback = 6,
        SupportRollbackSelective = 7,
        RollbackFailed = 8,
        RollbackAbandoned = 9,
        InEscrow = 10,
        EscrowRollback = 11
    }

    internal class TradedCurrency
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }

        [JsonProperty("contextid")]
        public uint ContextId { get; set; }

        [JsonProperty("currencyid")]
        public uint CurrencyId { get; set; }

        [JsonProperty("amount")]
        public uint AmountTraded { get; set; }

        [JsonProperty("classid")]
        public uint ClassId { get; set; }

        [JsonProperty("new_currencyid")]
        public ulong CurrencyIdAfterTrade { get; set; }

        [JsonProperty("new_contextid")]
        public uint ContextIdAfterTrade { get; set; }

        [JsonProperty("rollback_new_currencyid")]
        public ulong CurrencyIdAfterRollback { get; set; }

        [JsonProperty("rollback_new_contextid")]
        public uint ContextIdAfterRollback { get; set; }
    }

    internal class TradeAsset
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }

        [JsonProperty("contextid")]
        public uint ContextId { get; set; }

        [JsonProperty("assetid")]
        public ulong AssetId { get; set; }

        [JsonProperty("currencyid")]
        public ulong CurrencyId { get; set; }

        [JsonProperty("classid")]
        public uint ClassId { get; set; }

        [JsonProperty("instanceid")]
        public uint InstanceId { get; set; }

        [JsonProperty("amount")]
        public uint AmountOffered { get; set; }

        [JsonProperty("missing")]
        public bool IsMissing { get; set; }
    }

    internal class TradedAsset
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }

        [JsonProperty("contextid")]
        public uint ContextId { get; set; }

        [JsonProperty("assetid")]
        public ulong AssetId { get; set; }

        [JsonProperty("amount")]
        public uint AmountTraded { get; set; }

        [JsonProperty("classid")]
        public uint ClassId { get; set; }

        [JsonProperty("instanceid")]
        public uint InstanceId { get; set; }

        [JsonProperty("new_assetid")]
        public ulong AssetIdAfterTrade { get; set; }

        [JsonProperty("new_contextid")]
        public ulong ContextIdAfterTrade { get; set; }

        [JsonProperty("rollback_new_assetid")]
        public ulong AssetIdAfterRollback { get; set; }

        [JsonProperty("rollback_new_contextid")]
        public ulong ContextIdAfterRollback { get; set; }
    }

    internal class Trade
    {
        [JsonProperty("tradeid")]
        public ulong TradeId { get; set; }

        [JsonProperty("steamid_other")]
        public ulong TradeParterSteamId { get; set; }

        [JsonProperty("time_init")]
        public ulong TimeTradeStarted { get; set; }

        [JsonProperty("time_escrow_end")]
        public ulong TimeEscrowEnds { get; set; }

        [JsonProperty("status")]
        public TradeStatus TradeStatus { get; set; }

        [JsonProperty("assets_received")]
        public IList<TradedAsset> AssetsReceived { get; set; }

        [JsonProperty("assets_given")]
        public IList<TradedAsset> AssetsGiven { get; set; }

        [JsonProperty("currency_received")]
        public IList<TradedCurrency> CurrencyReceived { get; set; }

        [JsonProperty("currency_given")]
        public IList<TradedCurrency> CurrencyGiven { get; set; }
    }

    internal class TradeHistoryResult
    {
        [JsonProperty("total_trades")]
        public uint TotalTradeCount { get; set; }

        [JsonProperty("more")]
        public bool AreMoreAvailable { get; set; }

        [JsonProperty("trades")]
        public IList<Trade> Trades { get; set; }

        [JsonProperty("descriptions")]
        public IList<string> Descriptions { get; set; }
    }

    internal class TradeHistoryResultContainer
    {
        [JsonProperty("response")]
        public TradeHistoryResult Result { get; set; }
    }
}