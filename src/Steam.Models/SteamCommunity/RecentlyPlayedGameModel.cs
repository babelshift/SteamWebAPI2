namespace Steam.Models.SteamCommunity
{
    public class RecentlyPlayedGameModel
    {
        public uint AppId { get; set; }

        public string Name { get; set; }

        public uint Playtime2Weeks { get; set; }

        public uint PlaytimeForever { get; set; }

        public string ImgIconUrl { get; set; }

        public string ImgLogoUrl { get; set; }
    }
}