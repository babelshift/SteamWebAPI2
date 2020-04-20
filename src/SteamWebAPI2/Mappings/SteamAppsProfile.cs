using System.Collections.Generic;
using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Mappings
{
    public class SteamAppsProfile : Profile
    {
        public SteamAppsProfile()
        {
            CreateMap<SteamApp, SteamAppModel>();
            CreateMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamApp>, IReadOnlyCollection<SteamAppModel>>(src.Result != null ? src.Result.Apps : null)
            );

            CreateMap<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>();
            CreateMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>(src.Result)
            );
        }
    }
}