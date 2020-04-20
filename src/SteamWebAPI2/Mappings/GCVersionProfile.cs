using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Mappings
{
    public class GCVersionProfile : Profile
    {
        public GCVersionProfile()
        {
            CreateMap<GameClientResult, GameClientResultModel>();
            CreateMap<GameClientResultContainer, GameClientResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<GameClientResult, GameClientResultModel>(src.Result)
            );
        }
    }
}