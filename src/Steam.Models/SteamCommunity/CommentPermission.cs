namespace Steam.Models.SteamCommunity
{
    /// <summary>
    /// Indicates the selected privacy/visibility level of the player's comments section on their Steam Community profile
    /// </summary>
    public enum CommentPermission
    {
        Unknown = 0,
        FriendsOnly = 1,
        Private = 2,
        Public = 3
    }
}