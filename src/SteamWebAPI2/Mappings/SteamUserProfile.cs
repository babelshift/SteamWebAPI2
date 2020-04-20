using System.Collections.Generic;
using AutoMapper;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;

namespace SteamWebAPI2.Mappings
{
    public class SteamUserProfile : Profile
    {
        public SteamUserProfile()
        {
            CreateMap<PlayerSummary, PlayerSummaryModel>();
            CreateMap<PlayerSummaryResultContainer, PlayerSummaryModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<PlayerSummary, PlayerSummaryModel>(src.Result != null ? src.Result.Players[0] : null)
            );
            CreateMap<PlayerSummaryResultContainer, IReadOnlyCollection<PlayerSummaryModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<PlayerSummary>, IReadOnlyCollection<PlayerSummaryModel>>(src.Result != null ? src.Result.Players : null)
            );

            CreateMap<Friend, FriendModel>();
            CreateMap<FriendsListResultContainer, IReadOnlyCollection<FriendModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<Friend>, IReadOnlyCollection<FriendModel>>(src.Result != null ? src.Result.Friends : null)
            );

            CreateMap<PlayerBans, PlayerBansModel>();
            CreateMap<PlayerBansContainer, IReadOnlyCollection<PlayerBansModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<PlayerBans>, IReadOnlyCollection<PlayerBansModel>>(src.PlayerBans)
            );

            CreateMap<UserGroupGid, ulong>().ConvertUsing(src => src.Gid);

            CreateMap<UserGroupListResultContainer, IReadOnlyCollection<ulong>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<UserGroupGid>, IReadOnlyCollection<ulong>>(src.Result != null ? src.Result.Groups : null)
            );

            CreateMap<ResolveVanityUrlResultContainer, ulong>().ConvertUsing(src => src.Result != null ? src.Result.SteamId : default(ulong));
        }
    }
}