namespace Steam.Models.SteamEconomy
{
    /// <summary>
    /// These are the different states for a trade offer.
    /// </summary>
    public enum TradeOfferState
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
}