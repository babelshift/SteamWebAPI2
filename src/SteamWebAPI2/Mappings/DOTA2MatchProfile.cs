using System.Collections.Generic;
using AutoMapper;
using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Mappings
{
    public class DOTA2MatchProfile : Profile
    {
        public DOTA2MatchProfile()
        {
            CreateMap<League, LeagueModel>()
                .ForMember(dest => dest.ImageInventoryPath, opts => opts.Ignore())
                .ForMember(dest => dest.ImageBannerPath, opts => opts.Ignore())
                .ForMember(dest => dest.NameLocalized, opts => opts.Ignore())
                .ForMember(dest => dest.DescriptionLocalized, opts => opts.Ignore())
                .ForMember(dest => dest.TypeName, opts => opts.Ignore())
                .ForMember(dest => dest.Tier, opts => opts.Ignore())
                .ForMember(dest => dest.Location, opts => opts.Ignore());
            CreateMap<LeagueResultContainer, IReadOnlyCollection<LeagueModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<League>, IReadOnlyCollection<LeagueModel>>(src.Result != null ? src.Result.Leagues : null)
            );

            CreateMap<LiveLeagueGame, LiveLeagueGameModel>();
            CreateMap<LiveLeagueGameTeamDireInfo, LiveLeagueGameTeamDireInfoModel>();
            CreateMap<LiveLeagueGameTeamRadiantInfo, LiveLeagueGameTeamRadiantInfoModel>();
            CreateMap<LiveLeagueGamePlayerInfo, LiveLeagueGamePlayerInfoModel>();
            CreateMap<LiveLeagueGameScoreboard, LiveLeagueGameScoreboardModel>();
            CreateMap<LiveLeagueGameTeamDireDetail, LiveLeagueGameTeamDireDetailModel>();
            CreateMap<LiveLeagueGameAbility, LiveLeagueGameAbilityModel>();
            CreateMap<LiveLeagueGameBan, LiveLeagueGameBanModel>();
            CreateMap<LiveLeagueGamePick, LiveLeagueGamePickModel>();
            CreateMap<LiveLeagueGameTeamRadiantDetail, LiveLeagueGameTeamRadiantDetailModel>();
            CreateMap<LiveLeagueGamePlayerDetail, LiveLeagueGamePlayerDetailModel>();
            CreateMap<LiveLeagueGameResultContainer, IReadOnlyCollection<LiveLeagueGameModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<LiveLeagueGame>, IReadOnlyCollection<LiveLeagueGameModel>>(src.Result != null ? src.Result.Games : null)
            );

            CreateMap<MatchDetailResult, MatchDetailModel>()
                .ForMember(dest => dest.StartTime, opts => opts.MapFrom(src => src.StartTime.ToDateTime()));
            CreateMap<MatchPlayer, MatchPlayerModel>();
            CreateMap<MatchPlayerAbilityUpgrade, MatchPlayerAbilityUpgradeModel>();
            CreateMap<MatchPickBan, MatchPickBanModel>();
            CreateMap<MatchDetailResultContainer, MatchDetailModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<MatchDetailResult, MatchDetailModel>(src.Result)
            );

            CreateMap<MatchHistoryMatch, MatchHistoryMatchModel>();
            CreateMap<MatchHistoryPlayer, MatchHistoryPlayerModel>();
            CreateMap<MatchHistoryResult, MatchHistoryModel>();
            CreateMap<MatchHistoryResultContainer, MatchHistoryModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<MatchHistoryResult, MatchHistoryModel>(src.Result)
            );

            CreateMap<MatchHistoryBySequenceNumberResult, MatchHistoryModel>()
                .ForMember(dest => dest.NumResults, opts => opts.Ignore())
                .ForMember(dest => dest.TotalResults, opts => opts.Ignore())
                .ForMember(dest => dest.ResultsRemaining, opts => opts.Ignore());
            CreateMap<MatchHistoryBySequenceNumberResultContainer, IReadOnlyCollection<MatchHistoryMatchModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<MatchHistoryMatch>, IReadOnlyCollection<MatchHistoryMatchModel>>(src.Result != null ? src.Result.Matches : null)
            );

            CreateMap<SteamWebAPI2.Models.DOTA2.TeamInfo, Steam.Models.DOTA2.TeamInfo>();
            CreateMap<TeamInfoResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamWebAPI2.Models.DOTA2.TeamInfo>, IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>(src.Result != null ? src.Result.Teams : null)
            );
        }
    }
}