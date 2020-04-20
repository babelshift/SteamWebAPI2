using AutoMapper;
using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;

namespace SteamWebAPI2.Mappings
{
    public class DOTA2FantasyProfile : Profile
    {
        public DOTA2FantasyProfile()
        {
            CreateMap<PlayerOfficialInfoResult, PlayerOfficialInfoModel>();
            CreateMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<PlayerOfficialInfoResult, PlayerOfficialInfoModel>(src.Result)
            );

            CreateMap<ProPlayerInfo, ProPlayerInfoModel>();
            CreateMap<ProPlayerLeaderboard, ProPlayerLeaderboardModel>();
            CreateMap<ProPlayerListResult, ProPlayerDetailModel>();
        }
    }
}