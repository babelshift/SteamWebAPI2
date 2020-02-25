namespace Steam.Models.SteamEconomy
{
    public class TradedCurrencyModel
    {
        public uint AppId { get; set; }

        public uint ContextId { get; set; }

        public uint CurrencyId { get; set; }

        public uint AmountTraded { get; set; }

        public uint ClassId { get; set; }

        /// <summary>
        /// The currency ID given after the trade completed
        /// </summary>
        public ulong CurrencyIdAfterTrade { get; set; }

        /// <summary>
        /// The context ID the currency was placed in
        /// </summary>
        public uint ContextIdAfterTrade { get; set; }

        /// <summary>
        /// If the trade has been rolled back, the new currency ID given in the rollback
        /// </summary>
        public ulong CurrencyIdAfterRollback { get; set; }

        /// <summary>
        /// If the trade has been rolled back, the context ID the new asset was placed in
        /// </summary>
        public uint ContextIdAfterRollback { get; set; }
    }
}