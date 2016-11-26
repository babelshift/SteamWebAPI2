using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SteamWebAPI2.Models.SteamCommunity
{
    [DataContract(Name = "profile", Namespace = "")]
    internal class SteamCommunityProfile
    {
        [DataMember(Name = "steamID64", Order = 0)]
        public ulong SteamID64 { get; set; }

        [DataMember(Name = "steamID", Order = 1)]
        public string SteamID { get; set; }

        [DataMember(Name = "onlineState", Order = 2)]
        public string OnlineState { get; set; }

        [DataMember(Name = "stateMessage", Order = 3)]
        public string StateMessage { get; set; }

        [DataMember(Name = "privacyState", Order = 4)]
        public string PrivacyState { get; set; }

        [DataMember(Name = "visibilityState", Order = 5)]
        public byte VisibilityState { get; set; }

        [DataMember(Name = "avatarIcon", Order = 6)]
        public string AvatarIcon { get; set; }

        [DataMember(Name = "avatarMedium", Order = 7)]
        public string AvatarMedium { get; set; }

        [DataMember(Name = "avatarFull", Order = 8)]
        public string AvatarFull { get; set; }

        [DataMember(Name = "vacBanned", Order = 9)]
        public byte VacBanned {get; set; }

        [DataMember(Name = "tradeBanState", Order = 10)]
        public string TradeBanState { get; set; }

        [DataMember(Name = "isLimitedAccount", Order = 11)]
        public byte IsLimitedAccount { get; set; }

        [DataMember(Name = "customURL", Order = 12)]
        public string CustomURL { get; set; }

        [DataMember(Name = "inGameServerIP", Order = 13)]
        public string InGameServerIP { get; set; }

        [DataMember(Name = "inGameInfo", Order = 14)]
        public ProfileInGameInfo InGameInfo { get; set; }

        [DataMember(Name = "memberSince", Order = 15)]
        public string MemberSince { get; set; }

        [DataMember(Name = "steamRating", Order = 16)]
        public string SteamRating { get; set; }

        [DataMember(Name = "hoursPlayed2Wk", Order = 17)]
        public decimal HoursPlayed2Wk { get; set; }

        [DataMember(Name = "headline", Order = 18)]
        public string Headline { get; set; }

        [DataMember(Name = "location", Order = 19)]
        public string Location { get; set; }

        [DataMember(Name = "realname", Order = 20)]
        public string RealName { get; set; }

        [DataMember(Name = "summary", Order = 21)]
        public string Summary { get; set; }

        [DataMember(Name = "mostPlayedGames", Order = 22)]
        public ProfileMostPlayedGameList MostPlayedGames { get; set; }

        [DataMember(Name = "groups", Order = 23)]
        public ProfileGroupList Groups { get; set; }
    }

    [DataContract(Name = "inGameInfo", Namespace = "")]
    internal class ProfileInGameInfo
    {
        [DataMember(Name = "gameName", Order = 0)]
        public string GameName { get; set; }

        [DataMember(Name = "gameLink", Order = 1)]
        public string GameLink { get; set; }

        [DataMember(Name = "gameIcon", Order = 2)]
        public string GameIcon { get; set; }

        [DataMember(Name = "gameLogo", Order = 3)]
        public string GameLogo { get; set; }

        [DataMember(Name = "gameLogoSmall", Order = 4)]
        public string GameLogoSmall { get; set; }
    }

    [DataContract(Name = "mostPlayedGame", Namespace = "")]
    internal class ProfileMostPlayedGame
    {
        [DataMember(Name = "gameName", Order = 0)]
        public string GameName { get; set; }

        [DataMember(Name = "gameLink", Order = 1)]
        public string GameLink { get; set; }

        [DataMember(Name = "gameIcon", Order = 2)]
        public string GameIcon { get; set; }

        [DataMember(Name = "gameLogo", Order = 3)]
        public string GameLogo { get; set; }

        [DataMember(Name = "gameLogoSmall", Order = 4)]
        public string GameLogoSmall { get; set; }

        [DataMember(Name = "hoursPlayed", Order = 5)]
        public decimal HoursPlayed { get; set; }

        [DataMember(Name = "hoursOnRecord", Order = 6)]
        public string HoursOnRecord { get; set; }

        [DataMember(Name = "statsName", Order = 7)]
        public string StatsName { get; set; }
    }

    [DataContract(Name = "profileGroup", Namespace = "")]
    internal class ProfileGroup
    {
        [DataMember(Name = "groupID64", Order = 0)]
        public ulong GroupID64 { get; set; }

        [DataMember(Name = "groupName", Order = 1)]
        public string GroupName { get; set; }

        [DataMember(Name = "groupURL", Order = 2)]
        public string GroupURL { get; set; }

        [DataMember(Name = "headline", Order = 3)]
        public string Headline { get; set; }

        [DataMember(Name = "summary", Order = 4)]
        public string Summary { get; set; }

        [DataMember(Name = "avatarIcon", Order = 5)]
        public string AvatarIcon { get; set; }

        [DataMember(Name = "avatarMedium", Order = 6)]
        public string AvatarMedium { get; set; }

        [DataMember(Name = "avatarFull", Order = 7)]
        public string AvatarFull { get; set; }

        [DataMember(Name = "memberCount", Order = 8)]
        public uint MemberCount { get; set; }
        
        public bool MemberCountSpecified { get; set; }

        [DataMember(Name = "membersInChat", Order = 9)]
        public uint MembersInChat { get; set; }
        
        public bool MembersInChatSpecified { get; set; }

        [DataMember(Name = "membersInGame", Order = 10)]
        public uint MembersInGame { get; set; }
        
        public bool MembersInGameSpecified { get; set; }

        [DataMember(Name = "membersOnline", Order = 11)]
        public uint MembersOnline { get; set; }
        
        public bool MembersOnlineSpecified { get; set; }
    }

    [CollectionDataContract(ItemName = "mostPlayedGame", Namespace = "")]
    internal class ProfileMostPlayedGameList : List<ProfileMostPlayedGame>
    {
        public ProfileMostPlayedGameList() { }
        public ProfileMostPlayedGameList(IEnumerable<ProfileMostPlayedGame> collection) : base(collection) { }
    }

    [CollectionDataContract(ItemName = "group", Namespace = "")]
    internal class ProfileGroupList : List<ProfileGroup>
    {
        public ProfileGroupList() { }
        public ProfileGroupList(IEnumerable<ProfileGroup> collection) : base(collection) { }
    }
}