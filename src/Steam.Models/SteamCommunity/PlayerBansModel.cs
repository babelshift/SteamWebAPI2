namespace Steam.Models.SteamCommunity
{
    public class PlayerBansModel
    {
        public string SteamId { get; set; }

        public bool CommunityBanned { get; set; }

        public bool VACBanned { get; set; }

        public uint NumberOfVACBans { get; set; }

        public uint DaysSinceLastBan { get; set; }

        public uint NumberOfGameBans { get; set; }

        public string EconomyBan { get; set; }
    }
}