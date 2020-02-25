using System;
using System.Collections.Generic;

namespace Steam.Models.SteamCommunity
{
    public class SteamCommunityProfileModel
    {
        public ulong SteamID { get; set; }
        public string State { get; set; }
        public string StateMessage { get; set; }
        public uint VisibilityState { get; set; } // what is this?
        public Uri Avatar { get; set; }
        public Uri AvatarMedium { get; set; }
        public Uri AvatarFull { get; set; }
        public bool IsVacBanned { get; set; }
        public string TradeBanState { get; set; }
        public bool IsLimitedAccount { get; set; }
        public string CustomURL { get; set; }
        public string MemberSince { get; set; }
        public double SteamRating { get; set; }
        public double HoursPlayedLastTwoWeeks { get; set; }
        public string Headline { get; set; }
        public string Location { get; set; }
        public string RealName { get; set; }
        public string Summary { get; set; }
        public IReadOnlyCollection<SteamCommunityProfileMostPlayedGameModel> MostPlayedGames { get; set; }
        public string InGameServerIP { get; set; }
        public InGameInfoModel InGameInfo { get; set; }
    }

    public class SteamCommunityProfileMostPlayedGameModel
    {
        public string Name { get; set; }
        public Uri Link { get; set; }
        public Uri Icon { get; set; }
        public Uri Logo { get; set; }
        public Uri LogoSmall { get; set; }
        public double HoursPlayed { get; set; }
        public double HoursOnRecord { get; set; }
        public string StatsName { get; set; }
    }

    public class InGameInfoModel
    {
        public string GameName { get; set; }
        public string GameLink { get; set; }
        public string GameIcon { get; set; }
        public string GameLogo { get; set; }
        public string GameLogoSmall { get; set; }
    }
}