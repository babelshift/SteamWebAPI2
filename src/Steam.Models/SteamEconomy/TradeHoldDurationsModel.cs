using System;

namespace Steam.Models.SteamEconomy
{
    public class TradeHoldDurationsModel
    {
        public TimeSpan EscrowEndDuration { get; set; }

        public DateTime EscrowEndDate { get; set; }
    }
}