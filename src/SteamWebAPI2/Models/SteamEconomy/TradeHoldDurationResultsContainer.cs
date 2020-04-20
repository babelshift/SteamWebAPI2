using Newtonsoft.Json;
using System;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class TradeHoldDurations
    {
        [JsonProperty("escrow_end_duration_seconds")]
        public uint EscrowEndDurationSeconds { get; set; }
        
        [JsonProperty("escrow_end_date")]
        public uint EscrowEndDate { get; set; }

        [JsonProperty("escrow_end_date_rfc3339")]
        public DateTime EscrowEndDateRfc3339 { get; set;}
    }

    internal class TradeHoldDurationsResult
    {
        [JsonProperty("my_escrow")]
        public TradeHoldDurations MyEscrow { get; set; }
        
        [JsonProperty("their_escrow")]
        public TradeHoldDurations TheirEscrow { get; set; }
        
        [JsonProperty("both_escrow")]
        public TradeHoldDurations BothEscrow { get; set; }
    }

    internal class TradeHoldDurationsResultContainer
    {
        [JsonProperty("response")]
        public TradeHoldDurationsResult Result { get; set; }
    }
}