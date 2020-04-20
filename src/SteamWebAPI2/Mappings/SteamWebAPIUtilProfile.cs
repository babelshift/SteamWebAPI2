using System.Collections.Generic;
using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Mappings
{
    public class SteamWebAPIUtilProfile : Profile
    {
        public SteamWebAPIUtilProfile()
        {
            CreateMap<SteamServerInfo, SteamServerInfoModel>();

            CreateMap<SteamInterface, SteamInterfaceModel>();
            CreateMap<SteamMethod, SteamMethodModel>();
            CreateMap<SteamParameter, SteamParameterModel>();
            CreateMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamInterface>, IReadOnlyCollection<SteamInterfaceModel>>(src.Result != null ? src.Result.Interfaces : null)
            );

        }
    }
}