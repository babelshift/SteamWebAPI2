using System.Collections.Generic;
using AutoMapper;
using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Models.GameEconomy;

namespace SteamWebAPI2.Mappings
{
    public class DOTA2EconProfile : Profile
    {
        public DOTA2EconProfile()
        {
            CreateMap<Hero, HeroModel>();
            CreateMap<HeroResultContainer, IReadOnlyCollection<HeroModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<Hero>, IReadOnlyCollection<HeroModel>>(src.Result != null ? src.Result.Heroes : null)
            );

            CreateMap<GameItem, GameItemModel>();
            CreateMap<GameItemResultContainer, IReadOnlyCollection<GameItemModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<GameItem>, IReadOnlyCollection<GameItemModel>>(src.Result != null ? src.Result.Items : null)
            );

            CreateMap<ItemIconPathResultContainer, string>().ConvertUsing(src => src.Result != null ? src.Result.Path : null);

            CreateMap<SchemaQualities, Steam.Models.TF2.SchemaQualitiesModel>();
            CreateMap<SchemaOriginName, Steam.Models.TF2.SchemaOriginNameModel>();
            CreateMap<SchemaItem, Steam.Models.TF2.SchemaItemModel>();
            CreateMap<SchemaCapabilities, Steam.Models.TF2.SchemaCapabilitiesModel>();
            CreateMap<SchemaStyle, Steam.Models.TF2.SchemaStyleModel>();
            CreateMap<SchemaAdditionalHiddenBodygroups, Steam.Models.TF2.SchemaAdditionalHiddenBodygroupsModel>();
            CreateMap<SchemaItemAttribute, Steam.Models.TF2.SchemaItemAttributeModel>();
            CreateMap<SchemaPerClassLoadoutSlots, Steam.Models.TF2.SchemaPerClassLoadoutSlotsModel>();
            CreateMap<SchemaTool, Steam.Models.TF2.SchemaToolModel>();
            CreateMap<SchemaUsageCapabilities, Steam.Models.TF2.SchemaUsageCapabilitiesModel>();
            CreateMap<SchemaAttribute, Steam.Models.TF2.SchemaAttributeModel>();
            CreateMap<SchemaItemSet, Steam.Models.TF2.SchemaItemSetModel>();
            CreateMap<SchemaItemSetAttribute, Steam.Models.TF2.SchemaItemSetAttributeModel>();
            CreateMap<SchemaAttributeControlledAttachedParticle, Steam.Models.TF2.SchemaAttributeControlledAttachedParticleModel>();
            CreateMap<SchemaItemLevel, Steam.Models.TF2.SchemaItemLevelModel>();
            CreateMap<SchemaLevel, Steam.Models.TF2.SchemaLevelModel>();
            CreateMap<SchemaKillEaterScoreType, Steam.Models.TF2.SchemaKillEaterScoreTypeModel>();
            CreateMap<SchemaStringLookup, Steam.Models.TF2.SchemaStringLookupModel>();
            CreateMap<SchemaString, Steam.Models.TF2.SchemaStringModel>();

            // TODO: Rework the way Schema models are used for different games (TF2 / DOTA2)
            //CreateMap<SchemaQualities, Steam.Models.DOTA2.SchemaQualityModel>()
            //    .ForMember(dest => dest.Name, opts => opts.Ignore())
            //    .ForMember(dest => dest.Value, opts => opts.Ignore())
            //    .ForMember(dest => dest.HexColor, opts => opts.Ignore());
            //CreateMap<SchemaResult, Steam.Models.DOTA2.SchemaModel>()
            //    .ForMember(dest => dest.GameInfo, opts => opts.Ignore())
            //    .ForMember(dest => dest.Rarities, opts => opts.Ignore())
            //    .ForMember(dest => dest.Colors, opts => opts.Ignore())
            //    .ForMember(dest => dest.Prefabs, opts => opts.Ignore())
            //    .ForMember(dest => dest.ItemAutographs, opts => opts.Ignore());
            //CreateMap<SchemaResultContainer, Steam.Models.DOTA2.SchemaModel>().ConvertUsing(
            //    src => Mapper.Map<SchemaResult, Steam.Models.DOTA2.SchemaModel>(src.Result)
            //);

            CreateMap<Rarity, RarityModel>();
            CreateMap<RarityResultContainer, IReadOnlyCollection<RarityModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<Rarity>, IReadOnlyCollection<RarityModel>>(src.Result != null ? src.Result.Rarities : null)
            );

            CreateMap<PrizePoolResultContainer, uint>().ConvertUsing(src => src.Result != null ? src.Result.PrizePool : default(uint));
        }
    }
}