using System.Collections.Generic;
using AutoMapper;
using Steam.Models.CSGO;
using Steam.Models.GameEconomy;
using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Mappings
{
    public class SteamEconomyProfile : Profile
    {
        public SteamEconomyProfile()
        {
            CreateMap<AssetClassAction, AssetClassActionModel>();
            CreateMap<AssetClassAppDataFilter, AssetClassAppDataFilterModel>();
            CreateMap<AssetClassAppData, AssetClassAppDataModel>();
            CreateMap<AssetClassDescription, AssetClassDescriptionModel>();
            CreateMap<AssetClassInfo, AssetClassInfoModel>();
            CreateMap<AssetClassMarketAction, AssetClassMarketActionModel>();
            CreateMap<AssetClassTag, AssetClassTagModel>();
            CreateMap<AssetClassInfoResult, AssetClassInfoResultModel>();
            CreateMap<AssetClassInfoResultContainer, AssetClassInfoResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<AssetClassInfoResult, AssetClassInfoResultModel>(src.Result)
            );

            CreateMap<AssetPrices, AssetPricesModel>();
            CreateMap<Asset, AssetModel>();
            CreateMap<AssetClass, AssetClassModel>();
            CreateMap<AssetTags, AssetTagsModel>();
            CreateMap<AssetTagIds, AssetTagIdsModel>();
            CreateMap<AssetPriceResult, AssetPriceResultModel>();
            CreateMap<AssetPriceResultContainer, AssetPriceResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<AssetPriceResult, AssetPriceResultModel>(src.Result)
            );

            // Everything below this needs to be organized and moved to separate profiles

            CreateMap<SchemaUrlResultContainer, string>().ConvertUsing(src
                => src.Result != null ? src.Result.ItemsGameUrl : null);

            CreateMap<StoreBanner, StoreBannerModel>();
            CreateMap<StoreCarouselData, StoreCarouselDataModel>();
            CreateMap<StoreConfig, StoreConfigModel>();
            CreateMap<StoreDropdownData, StoreDropdownDataModel>();
            CreateMap<StoreDropdown, StoreDropdownModel>();
            CreateMap<StoreFilterAllElement, StoreFilterAllElementModel>();
            CreateMap<StoreFilterElement, StoreFilterElementModel>();
            CreateMap<StoreFilter, StoreFilterModel>();
            CreateMap<StoreHomePageData, StoreHomePageDataModel>();
            CreateMap<StoreMetaDataResult, StoreMetaDataModel>();
            CreateMap<StorePlayerClassData, StorePlayerClassDataModel>();
            CreateMap<StorePopularItem, StorePopularItemModel>();
            CreateMap<StorePrefab, StorePrefabModel>();
            CreateMap<StoreSorterId, StoreSorterIdModel>();
            CreateMap<StoreSorter, StoreSorterModel>();
            CreateMap<StoreSorting, StoreSortingModel>();
            CreateMap<StoreTabChild, StoreTabChildModel>();
            CreateMap<StoreTab, StoreTabModel>();
            CreateMap<StoreSortingPrefab, StoreSortingPrefabModel>();
            CreateMap<StoreMetaDataResultContainer, StoreMetaDataModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<StoreMetaDataResult, StoreMetaDataModel>(src.Result)
            );

            CreateMap<StoreStatusResultContainer, uint>().ConvertUsing(src =>
                src.Result != null ? src.Result.StoreStatus : default(uint)
            );

            CreateMap<ServerStatusApp, ServerStatusAppModel>();
            CreateMap<ServerStatusResult, ServerStatusModel>();
            CreateMap<ServerStatusMatchmaking, ServerStatusMatchmakingModel>();
            CreateMap<ServerStatusServices, ServerStatusServicesModel>();
            CreateMap<ServerStatusDatacenter, ServerStatusDatacenterModel>();
            CreateMap<ServerStatusResultContainer, ServerStatusModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<ServerStatusResult, ServerStatusModel>(src.Result)
            );

            CreateMap<GameMapsPlaytimeContainer, IEnumerable<GameMapsPlaytimeModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IEnumerable<GameMapsPlaytime>, IEnumerable<GameMapsPlaytimeModel>>(src.Result.Playtimes)
            );
            CreateMap<GameMapsPlaytime, GameMapsPlaytimeModel>()
                .ForMember(dest => dest.IntervalStartTimeStamp, opts => opts.MapFrom(source =>
                    source.IntervalStartTimeStamp.ToDateTime()
                )
            );

            CreateMap<EconItem, EconItemModel>();
            CreateMap<EconItemAttribute, EconItemAttributeModel>();
            CreateMap<EconItemAttributeAccountInfo, EconItemAttributeAccountInfoModel>();
            CreateMap<EconItemEquipped, EconItemEquippedModel>();
            CreateMap<EconItemResult, EconItemResultModel>();
            CreateMap<EconItemResultContainer, EconItemResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<EconItemResult, EconItemResultModel>(src.Result)
            );
        }
    }
}