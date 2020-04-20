using System.Collections.Generic;
using AutoMapper;
using Steam.Models.TF2;
using SteamWebAPI2.Models.TF2;

namespace SteamWebAPI2.Mappings
{
    public class TFItemsProfile : Profile
    {
        public TFItemsProfile()
        {
            CreateMap<GoldenWrench, GoldenWrenchModel>();
            CreateMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<GoldenWrench>, IReadOnlyCollection<GoldenWrenchModel>>(src.Result != null ? src.Result.GoldenWrenches : null)
            );

        }
    }
}