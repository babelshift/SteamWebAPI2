namespace Steam.Models.SteamCommunity
{
    /// <summary>
    /// Indicates the current status of the user on the Steam network
    /// </summary>
    public enum UserStatus
    {
        Offline = 0,
        Online = 1,
        Busy = 2,
        Away = 3,
        Snooze = 4,
        Unknown = 5,
        InGame = 6
    }
}