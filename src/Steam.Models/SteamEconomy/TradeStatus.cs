namespace Steam.Models.SteamEconomy
{
    /// <summary>
    /// Tracks the status of a trade after a trade offer has been accepted.
    /// </summary>
    public enum TradeStatus
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
}