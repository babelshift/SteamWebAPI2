namespace Steam.Models.SteamCommunity
{
    public class BadgeModel
    {
        public uint BadgeId { get; set; }

        public uint Level { get; set; }

        public ulong CompletionTime { get; set; }

        public uint Xp { get; set; }

        public uint Scarcity { get; set; }

        public uint? AppId { get; set; }

        public string CommunityItemId { get; set; }

        public uint? BorderColor { get; set; }
    }
}