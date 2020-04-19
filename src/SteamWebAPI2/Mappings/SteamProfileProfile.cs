using System;
using AutoMapper;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;

namespace SteamWebAPI2.Mappings
{
    public class SteamProfileProfile : Profile
    {
        public SteamProfileProfile()
        {
            CreateMap<ProfileInGameInfo, InGameInfoModel>()
                .ForMember(dest => dest.GameIcon, opts => opts.MapFrom(source => source.GameIcon))
                .ForMember(dest => dest.GameLink, opts => opts.MapFrom(source => source.GameLink))
                .ForMember(dest => dest.GameLogo, opts => opts.MapFrom(source => source.GameLogo))
                .ForMember(dest => dest.GameLogoSmall, opts => opts.MapFrom(source => source.GameLogoSmall))
                .ForMember(dest => dest.GameName, opts => opts.MapFrom(source => source.GameName));

            CreateMap<ProfileMostPlayedGame, SteamCommunityProfileMostPlayedGameModel>()
                .ForMember(dest => dest.Link, opts => opts.MapFrom(source => new Uri(source.GameLink)))
                .ForMember(dest => dest.Icon, opts => opts.MapFrom(source => new Uri(source.GameIcon)))
                .ForMember(dest => dest.Logo, opts => opts.MapFrom(source => new Uri(source.GameLogo)))
                .ForMember(dest => dest.LogoSmall, opts => opts.MapFrom(source => new Uri(source.GameLogoSmall)))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(source => source.GameName))
                .ForMember(dest => dest.HoursOnRecord, opts => opts.MapFrom(source => !string.IsNullOrEmpty(source.HoursOnRecord) ? double.Parse(source.HoursOnRecord) : 0d))
                .ForMember(dest => dest.HoursPlayed, opts => opts.MapFrom(source => (double)source.HoursPlayed))
                .ForMember(dest => dest.StatsName, opts => opts.MapFrom(source => source.StatsName));

            CreateMap<SteamCommunityProfile, SteamCommunityProfileModel>()
                .ForMember(dest => dest.AvatarFull, opts => opts.MapFrom(source => new Uri(source.AvatarFull)))
                .ForMember(dest => dest.Avatar, opts => opts.MapFrom(source => new Uri(source.AvatarIcon)))
                .ForMember(dest => dest.AvatarMedium, opts => opts.MapFrom(source => new Uri(source.AvatarMedium)))
                .ForMember(dest => dest.CustomURL, opts => opts.MapFrom(source => source.CustomURL))
                .ForMember(dest => dest.MostPlayedGames, opts => opts.MapFrom(source => source.MostPlayedGames))
                .ForMember(dest => dest.Headline, opts => opts.MapFrom(source => source.Headline))
                .ForMember(dest => dest.HoursPlayedLastTwoWeeks, opts => opts.MapFrom(source => source.HoursPlayed2Wk))
                .ForMember(dest => dest.IsLimitedAccount, opts => opts.MapFrom(source => source.IsLimitedAccount == 1 ? true : false))
                .ForMember(dest => dest.Location, opts => opts.MapFrom(source => source.Location))
                .ForMember(dest => dest.MemberSince, opts => opts.MapFrom(source => source.MemberSince))
                .ForMember(dest => dest.State, opts => opts.MapFrom(source => source.OnlineState))
                .ForMember(dest => dest.StateMessage, opts => opts.MapFrom(source => source.StateMessage))
                .ForMember(dest => dest.SteamID, opts => opts.MapFrom(source => source.SteamID64))
                .ForMember(dest => dest.SteamRating, opts => opts.MapFrom(source => !string.IsNullOrEmpty(source.SteamRating) ? double.Parse(source.SteamRating) : 0d))
                .ForMember(dest => dest.Summary, opts => opts.MapFrom(source => source.Summary))
                .ForMember(dest => dest.TradeBanState, opts => opts.MapFrom(source => source.TradeBanState))
                .ForMember(dest => dest.IsVacBanned, opts => opts.MapFrom(source => source.VacBanned == 1 ? true : false))
                .ForMember(dest => dest.VisibilityState, opts => opts.MapFrom(source => source.VisibilityState))
                .ForMember(dest => dest.InGameServerIP, opts => opts.MapFrom(source => source.InGameServerIP))
                .ForMember(dest => dest.InGameInfo, opts => opts.MapFrom(source => source.InGameInfo));
        }
    }
}