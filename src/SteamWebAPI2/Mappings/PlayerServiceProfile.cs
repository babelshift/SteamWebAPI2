using System;
using System.Collections.Generic;
using AutoMapper;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;

namespace SteamWebAPI2.Mappings
{
    public class PlayerServiceProfile : Profile
    {
        public PlayerServiceProfile()
        {

            CreateMap<PlayingSharedGameResultContainer, ulong?>()
                .ConvertUsing(src => src.Result != null ? src.Result.LenderSteamId : null);

            CreateMap<CommunityBadgeProgressResultContainer, IReadOnlyCollection<BadgeQuestModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<BadgeQuest>, IReadOnlyCollection<BadgeQuestModel>>(src.Result?.Quests)
            );

            CreateMap<Badge, BadgeModel>();
            CreateMap<BadgeQuest, BadgeQuestModel>();
            CreateMap<BadgesResult, BadgesResultModel>();
            CreateMap<BadgesResultContainer, BadgesResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<BadgesResult, BadgesResultModel>(src.Result)
            );

            CreateMap<SteamLevelResultContainer, uint?>().ConvertUsing((src, dest) =>
            {
                if (src.Result == null) { return null; }
                else { return src.Result.PlayerLevel; }
            });

            CreateMap<OwnedGame, OwnedGameModel>()
            .ForMember(dest => dest.PlaytimeLastTwoWeeks, opts => opts.MapFrom((src, dest) =>
            {
                if (!src.Playtime2weeks.HasValue)
                {
                    return (TimeSpan?)null;
                }
                return TimeSpan.FromMinutes(src.Playtime2weeks.Value);
            }))
            .ForMember(dest => dest.PlaytimeForever, opts => opts.MapFrom((src, dest) =>
            {
                return TimeSpan.FromMinutes(src.PlaytimeForever);
            }));
            CreateMap<OwnedGamesResult, OwnedGamesResultModel>();
            CreateMap<OwnedGamesResultContainer, OwnedGamesResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<OwnedGamesResult, OwnedGamesResultModel>(src.Result)
            );

            CreateMap<RecentlyPlayedGame, RecentlyPlayedGameModel>();
            CreateMap<RecentlyPlayedGameResult, RecentlyPlayedGamesResultModel>();
            CreateMap<RecentlyPlayedGameResultContainer, RecentlyPlayedGamesResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<RecentlyPlayedGameResult, RecentlyPlayedGamesResultModel>(src.Result)
            );
        }
    }
}