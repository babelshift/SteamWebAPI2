using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Mappings
{
    public class SteamNewsProfile : Profile
    {
        public SteamNewsProfile()
        {
            CreateMap<NewsItem, NewsItemModel>();
            CreateMap<SteamNewsResult, SteamNewsResultModel>();
            CreateMap<SteamNewsResultContainer, SteamNewsResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<SteamNewsResult, SteamNewsResultModel>(src.Result)
            );
        }
    }
}