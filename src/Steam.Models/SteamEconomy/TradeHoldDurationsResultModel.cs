namespace Steam.Models.SteamEconomy
{
    public class TradeHoldDurationsResultModel
    {
        public TradeHoldDurationsModel MyEscrow { get; set; }

        public TradeHoldDurationsModel TheirEscrow { get; set; }

        public TradeHoldDurationsModel BothEscrow { get; set; }
    }
}