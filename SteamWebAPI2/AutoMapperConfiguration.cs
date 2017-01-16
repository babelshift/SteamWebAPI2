using AutoMapper;
using Steam.Models;
using Steam.Models.CSGO;
using Steam.Models.DOTA2;
using Steam.Models.GameEconomy;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamEconomy;
using Steam.Models.SteamPlayer;
using Steam.Models.SteamStore;
using Steam.Models.TF2;
using SteamWebAPI2.Models;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Models.SteamStore;
using SteamWebAPI2.Models.TF2;
using SteamWebAPI2.Utilities;
using System;

namespace SteamWebAPI2
{
    internal static class AutoMapperConfiguration
    {
        private static MapperConfiguration config;
        private static IMapper mapper;

        public static IMapper Mapper { get { return mapper; } }

        public static void Initialize()
        {
            if (config == null)
            {
                config = new MapperConfiguration(x =>
                {
                    x.CreateMap<Hero, HeroModel>();
                    x.CreateMap<GameItem, GameItemModel>();

                    x.CreateMap<SchemaResult, Steam.Models.TF2.SchemaModel>();
                    x.CreateMap<SchemaQualities, Steam.Models.TF2.SchemaQualitiesModel>();
                    x.CreateMap<SchemaOriginName, Steam.Models.TF2.SchemaOriginNameModel>();
                    x.CreateMap<SchemaItem, Steam.Models.TF2.SchemaItemModel>();
                    x.CreateMap<SchemaCapabilities, Steam.Models.TF2.SchemaCapabilitiesModel>();
                    x.CreateMap<SchemaStyle, Steam.Models.TF2.SchemaStyleModel>();
                    x.CreateMap<SchemaAdditionalHiddenBodygroups, Steam.Models.TF2.SchemaAdditionalHiddenBodygroupsModel>();
                    x.CreateMap<SchemaItemAttribute, Steam.Models.TF2.SchemaItemAttributeModel>();
                    x.CreateMap<SchemaPerClassLoadoutSlots, Steam.Models.TF2.SchemaPerClassLoadoutSlotsModel>();
                    x.CreateMap<SchemaTool, Steam.Models.TF2.SchemaToolModel>();
                    x.CreateMap<SchemaUsageCapabilities, Steam.Models.TF2.SchemaUsageCapabilitiesModel>();
                    x.CreateMap<SchemaAttribute, Steam.Models.TF2.SchemaAttributeModel>();
                    x.CreateMap<SchemaItemSet, Steam.Models.TF2.SchemaItemSetModel>();
                    x.CreateMap<SchemaItemSetAttribute, Steam.Models.TF2.SchemaItemSetAttributeModel>();
                    x.CreateMap<SchemaAttributeControlledAttachedParticle, Steam.Models.TF2.SchemaAttributeControlledAttachedParticleModel>();
                    x.CreateMap<SchemaItemLevel, Steam.Models.TF2.SchemaItemLevelModel>();
                    x.CreateMap<SchemaLevel, Steam.Models.TF2.SchemaLevelModel>();
                    x.CreateMap<SchemaKillEaterScoreType, Steam.Models.TF2.SchemaKillEaterScoreTypeModel>();
                    x.CreateMap<SchemaStringLookup, Steam.Models.TF2.SchemaStringLookupModel>();
                    x.CreateMap<SchemaString, Steam.Models.TF2.SchemaStringModel>();

                    x.CreateMap<SchemaResult, Steam.Models.DOTA2.SchemaModel>();
                    //x.CreateMap<SchemaAdditionalHiddenBodygroups, SchemaAdditionalHiddenBodygroupsModel>();
                    //x.CreateMap<SchemaAttributeControlledAttachedParticle, SchemaAttributeControlledAttachedParticleModel>();
                    //x.CreateMap<SchemaAttribute, SchemaAttributeModel>();
                    //x.CreateMap<SchemaCapabilities, SchemaCapabilitiesModel>();
                    //x.CreateMap<SchemaItemAttribute, SchemaItemAttributeModel>();
                    //x.CreateMap<SchemaItemLevel, SchemaItemLevelModel>();
                    //x.CreateMap<SchemaItem, SchemaItemModel>();
                    //x.CreateMap<SchemaLevel, SchemaLevelModel>();
                    //x.CreateMap<SchemaItemSetAttribute, SchemaItemSetAttributeModel>();
                    //x.CreateMap<SchemaItemSet, SchemaItemSetModel>();
                    //x.CreateMap<SchemaKillEaterScoreType, SchemaKillEaterScoreTypeModel>();
                    //x.CreateMap<SchemaOriginName, SchemaOriginNameModel>();
                    //x.CreateMap<SchemaPerClassLoadoutSlots, SchemaPerClassLoadoutSlotsModel>();
                    //x.CreateMap<SchemaQualities, SchemaQualitiesModel>();
                    //x.CreateMap<SchemaStringLookup, SchemaStringLookupModel>();
                    //x.CreateMap<SchemaString, SchemaStringModel>();
                    //x.CreateMap<SchemaStyle, SchemaStyleModel>();
                    //x.CreateMap<SchemaTool, SchemaToolModel>();
                    //x.CreateMap<SchemaUsageCapabilities, SchemaUsageCapabilitiesModel>();

                    x.CreateMap<StoreBanner, StoreBannerModel>();
                    x.CreateMap<StoreCarouselData, StoreCarouselDataModel>();
                    x.CreateMap<StoreConfig, StoreConfigModel>();
                    x.CreateMap<StoreDropdownData, StoreDropdownDataModel>();
                    x.CreateMap<StoreDropdown, StoreDropdownModel>();
                    x.CreateMap<StoreFilterAllElement, StoreFilterAllElementModel>();
                    x.CreateMap<StoreFilterElement, StoreFilterElementModel>();
                    x.CreateMap<StoreFilter, StoreFilterModel>();
                    x.CreateMap<StoreHomePageData, StoreHomePageDataModel>();
                    x.CreateMap<StoreMetaDataResult, StoreMetaDataModel>();
                    x.CreateMap<StorePlayerClassData, StorePlayerClassDataModel>();
                    x.CreateMap<StorePopularItem, StorePopularItemModel>();
                    x.CreateMap<StorePrefab, StorePrefabModel>();
                    x.CreateMap<StoreSorterId, StoreSorterIdModel>();
                    x.CreateMap<StoreSorter, StoreSorterModel>();
                    x.CreateMap<StoreSorting, StoreSortingModel>();
                    x.CreateMap<StoreTabChild, StoreTabChildModel>();
                    x.CreateMap<StoreTab, StoreTabModel>();
                    x.CreateMap<StoreSortingPrefab, StoreSortingPrefabModel>();

                    x.CreateMap<GameClientResult, GameClientResultModel>();

                    x.CreateMap<BadgesResult, BadgesResultModel>();
                    x.CreateMap<Badge, BadgeModel>();
                    x.CreateMap<BadgeQuest, BadgeQuestModel>();

                    x.CreateMap<OwnedGame, OwnedGameModel>();
                    x.CreateMap<OwnedGamesResult, OwnedGamesResultModel>();

                    x.CreateMap<RecentlyPlayedGame, RecentlyPlayedGameModel>();
                    x.CreateMap<RecentlyPlayedGameResult, RecentlyPlayedGamesResultModel>();

                    x.CreateMap<SteamApp, SteamAppModel>();
                    x.CreateMap<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>();

                    x.CreateMap<AssetClassAction, AssetClassActionModel>();
                    x.CreateMap<AssetClassAppDataFilter, AssetClassAppDataFilterModel>();
                    x.CreateMap<AssetClassAppData, AssetClassAppDataModel>();
                    x.CreateMap<AssetClassDescription, AssetClassDescriptionModel>();
                    x.CreateMap<AssetClassInfo, AssetClassInfoModel>();
                    x.CreateMap<AssetClassInfoResult, AssetClassInfoResultModel>();
                    x.CreateMap<AssetClassMarketAction, AssetClassMarketActionModel>();
                    x.CreateMap<AssetClassTag, AssetClassTagModel>();

                    x.CreateMap<AssetPrices, AssetPricesModel>();
                    x.CreateMap<Asset, AssetModel>();
                    x.CreateMap<AssetClass, AssetClassModel>();
                    x.CreateMap<AssetTags, AssetTagsModel>();
                    x.CreateMap<AssetTagIds, AssetTagIdsModel>();
                    x.CreateMap<AssetPriceResult, AssetPriceResultModel>();

                    x.CreateMap<NewsItem, NewsItemModel>();
                    x.CreateMap<SteamNewsResult, SteamNewsResultModel>();

                    x.CreateMap<UGCFileDetails, UGCFileDetailsModel>();

                    x.CreateMap<PlayerSummary, PlayerSummaryModel>();

                    x.CreateMap<Friend, FriendModel>();

                    x.CreateMap<PlayerBans, PlayerBansModel>();

                    x.CreateMap<GlobalAchievementPercentage, GlobalAchievementPercentageModel>();

                    x.CreateMap<GlobalStat, GlobalStatModel>();

                    x.CreateMap<PlayerAchievementResult, PlayerAchievementResultModel>();
                    x.CreateMap<PlayerAchievement, PlayerAchievementModel>();

                    x.CreateMap<SchemaForGameResult, SchemaForGameResultModel>();
                    x.CreateMap<AvailableGameStats, AvailableGameStatsModel>();
                    x.CreateMap<SchemaGameAchievement, SchemaGameAchievementModel>();
                    x.CreateMap<SchemaGameStat, SchemaGameStatModel>();

                    x.CreateMap<UserStatsForGameResult, UserStatsForGameResultModel>();
                    x.CreateMap<UserStatAchievement, UserStatAchievementModel>();
                    x.CreateMap<UserStat, UserStatModel>();

                    x.CreateMap<GoldenWrench, GoldenWrenchModel>();

                    x.CreateMap<SteamServerInfo, SteamServerInfoModel>();

                    x.CreateMap<SteamInterface, SteamInterfaceModel>();
                    x.CreateMap<SteamMethod, SteamMethodModel>();
                    x.CreateMap<SteamParameter, SteamParameterModel>();

                    x.CreateMap<ServerStatusApp, ServerStatusAppModel>();
                    x.CreateMap<ServerStatusResult, ServerStatusModel>();
                    x.CreateMap<ServerStatusMatchmaking, ServerStatusMatchmakingModel>();
                    x.CreateMap<ServerStatusServices, ServerStatusServicesModel>();
                    x.CreateMap<ServerStatusDatacenter, ServerStatusDatacenterModel>();

                    x.CreateMap<ProPlayerListResult, ProPlayerDetailModel>();
                    x.CreateMap<ProPlayerInfo, ProPlayerInfoModel>();
                    x.CreateMap<ProPlayerLeaderboardModel, ProPlayerLeaderboard>();

                    x.CreateMap<MatchDetailResult, MatchDetailModel>();
                    x.CreateMap<MatchPlayer, MatchPlayerModel>();
                    x.CreateMap<MatchPlayerAbilityUpgrade, MatchPlayerAbilityUpgradeModel>();
                    x.CreateMap<MatchPickBan, MatchPickBanModel>();

                    x.CreateMap<MatchHistoryMatch, MatchHistoryMatchModel>();
                    x.CreateMap<MatchHistoryPlayer, MatchHistoryPlayerModel>();
                    x.CreateMap<MatchHistoryResult, MatchHistoryModel>();

                    x.CreateMap<TeamInfo, TeamInfoModel>();

                    x.CreateMap<EconItemResult, EconItemResultModel>();
                    x.CreateMap<EconItem, EconItemModel>();
                    x.CreateMap<EconItemAttribute, EconItemAttributeModel>();
                    x.CreateMap<EconItemAttributeAccountInfo, EconItemAttributeAccountInfoModel>();
                    x.CreateMap<EconItemEquipped, EconItemEquippedModel>();

                    x.CreateMap<MatchHistoryBySequenceNumberResult, MatchHistoryModel>();

                    x.CreateMap<LiveLeagueGame, LiveLeagueGameModel>();
                    x.CreateMap<LiveLeagueGameTeamDireInfo, LiveLeagueGameTeamDireInfoModel>();
                    x.CreateMap<LiveLeagueGameTeamRadiantInfo, LiveLeagueGameTeamRadiantInfoModel>();
                    x.CreateMap<LiveLeagueGamePlayerInfo, LiveLeagueGamePlayerInfoModel>();
                    x.CreateMap<LiveLeagueGameScoreboard, LiveLeagueGameScoreboardModel>();
                    x.CreateMap<LiveLeagueGameTeamDireDetail, LiveLeagueGameTeamDireDetailModel>();
                    x.CreateMap<LiveLeagueGameAbility, LiveLeagueGameAbilityModel>();
                    x.CreateMap<LiveLeagueGameBan, LiveLeagueGameBanModel>();
                    x.CreateMap<LiveLeagueGamePick, LiveLeagueGamePickModel>();
                    x.CreateMap<LiveLeagueGameTeamRadiantDetail, LiveLeagueGameTeamRadiantDetailModel>();
                    x.CreateMap<LiveLeagueGamePlayerDetail, LiveLeagueGamePlayerDetailModel>();

                    x.CreateMap<Data, StoreAppDetailsDataModel>();
                    x.CreateMap<SupportInfo, StoreSupportInfoModel>();
                    x.CreateMap<ReleaseDate, StoreReleaseDateModel>();
                    x.CreateMap<Recommendations, StoreRecommendationsModel>();
                    x.CreateMap<Movie, StoreMovieModel>();
                    x.CreateMap<Webm, StoreWebmModel>();
                    x.CreateMap<Screenshot, StoreScreenshotModel>();
                    x.CreateMap<Genre, StoreGenreModel>();
                    x.CreateMap<Category, StoreCategoryModel>();
                    x.CreateMap<Metacritic, StoreMetacriticModel>();
                    x.CreateMap<Platforms, StorePlatformsModel>();
                    x.CreateMap<PackageGroup, StorePackageGroupModel>();
                    x.CreateMap<Sub, StoreSubModel>();
                    x.CreateMap<LinuxRequirements, StoreLinuxRequirementsModel>();
                    x.CreateMap<MacRequirements, StoreMacRequirementsModel>();
                    x.CreateMap<PcRequirements, StorePcRequirementsModel>();

                    x.CreateMap<FeaturedCategoriesContainer, StoreFeaturedCategoriesModel>();
                    x.CreateMap<TrailerSlideshow, StoreTrailerSlideshowModel>();
                    x.CreateMap<Genres, StoreFeaturedCategoryGenreModel>();
                    x.CreateMap<NewReleases, StoreNewReleasesModel>();
                    x.CreateMap<TopSellers, StoreTopSellersModel>();
                    x.CreateMap<ComingSoon, StoreComingSoonModel>();
                    x.CreateMap<Specials, StoreSpecialsModel>();
                    x.CreateMap<Item, StoreItemModel>();

                    x.CreateMap<FeaturedProductsContainer, StoreFeaturedProductsModel>();
                    x.CreateMap<FeaturedLinux, StoreFeaturedLinuxModel>();
                    x.CreateMap<FeaturedMac, StoreFeaturedMacModel>();
                    x.CreateMap<FeaturedWin, StoreFeaturedWinModel>();
                    x.CreateMap<LargeCapsule, StoreLargeCapsuleModel>();

                    x.CreateMap<ProfileInGameInfo, InGameInfoModel>()
                        .ForMember(dest => dest.GameIcon, opts => opts.MapFrom(source => source.GameIcon))
                        .ForMember(dest => dest.GameLink, opts => opts.MapFrom(source => source.GameLink))
                        .ForMember(dest => dest.GameLogo, opts => opts.MapFrom(source => source.GameLogo))
                        .ForMember(dest => dest.GameLogoSmall, opts => opts.MapFrom(source => source.GameLogoSmall))
                        .ForMember(dest => dest.GameName, opts => opts.MapFrom(source => source.GameName));

                    x.CreateMap<ProfileMostPlayedGame, SteamCommunityProfileMostPlayedGameModel>()
                        .ForMember(dest => dest.Link, opts => opts.MapFrom(source => new Uri(source.GameLink)))
                        .ForMember(dest => dest.Icon, opts => opts.MapFrom(source => new Uri(source.GameIcon)))
                        .ForMember(dest => dest.Logo, opts => opts.MapFrom(source => new Uri(source.GameLogo)))
                        .ForMember(dest => dest.LogoSmall, opts => opts.MapFrom(source => new Uri(source.GameLogoSmall)))
                        .ForMember(dest => dest.Name, opts => opts.MapFrom(source => source.GameName))
                        .ForMember(dest => dest.HoursOnRecord, opts => opts.MapFrom(source => !String.IsNullOrEmpty(source.HoursOnRecord) ? double.Parse(source.HoursOnRecord) : 0d))
                        .ForMember(dest => dest.HoursPlayed, opts => opts.MapFrom(source => (double)source.HoursPlayed))
                        .ForMember(dest => dest.StatsName, opts => opts.MapFrom(source => source.StatsName));

                    x.CreateMap<SteamCommunityProfile, SteamCommunityProfileModel>()
                        .ForMember(dest => dest.AvatarFull, opts => opts.MapFrom(source => new Uri(source.AvatarFull)))
                        .ForMember(dest => dest.Avatar, opts => opts.MapFrom(source => new Uri(source.AvatarIcon)))
                        .ForMember(dest => dest.AvatarMedium, opts => opts.MapFrom(source => new Uri(source.AvatarMedium)))
                        .ForMember(dest => dest.CustomURL, opts => opts.MapFrom(source => source.CustomURL))
                        .ForMember(dest => dest.MostPlayedGames, opts => opts.MapFrom(source => source.MostPlayedGames))
                        .ForMember(dest => dest.Headline, opts => opts.MapFrom(source => source.Headline))
                        .ForMember(dest => dest.HoursPlayedLastTwoWeeks, opts => opts.MapFrom(source => source.HoursPlayed2Wk))
                        .ForMember(dest => dest.IsLimitedAccount, opts => opts.MapFrom(source => source.IsLimitedAccount == 1 ? true : false))
                        .ForMember(dest => dest.Location, opts => opts.MapFrom(source => source.Location))
                        .ForMember(dest => dest.MemberSince, opts => opts.MapFrom(source => source.MemberSince))
                        .ForMember(dest => dest.State, opts => opts.MapFrom(source => source.OnlineState))
                        .ForMember(dest => dest.StateMessage, opts => opts.MapFrom(source => source.StateMessage))
                        .ForMember(dest => dest.SteamID, opts => opts.MapFrom(source => source.SteamID64))
                        .ForMember(dest => dest.SteamRating, opts => opts.MapFrom(source => !String.IsNullOrEmpty(source.SteamRating) ? double.Parse(source.SteamRating) : 0d))
                        .ForMember(dest => dest.Summary, opts => opts.MapFrom(source => source.Summary))
                        .ForMember(dest => dest.TradeBanState, opts => opts.MapFrom(source => source.TradeBanState))
                        .ForMember(dest => dest.IsVacBanned, opts => opts.MapFrom(source => source.VacBanned == 1 ? true : false))
                        .ForMember(dest => dest.VisibilityState, opts => opts.MapFrom(source => source.VisibilityState))
                        .ForMember(dest => dest.InGameServerIP, opts => opts.MapFrom(source => source.InGameServerIP))
                        .ForMember(dest => dest.InGameInfo, opts => opts.MapFrom(source => source.InGameInfo));

                    x.CreateMap<Models.SteamEconomy.TradeStatus, Steam.Models.SteamEconomy.TradeStatus>();
                    x.CreateMap<Models.SteamEconomy.TradeOfferState, Steam.Models.SteamEconomy.TradeOfferState>();
                    x.CreateMap<Models.SteamEconomy.TradeOfferConfirmationMethod, Steam.Models.SteamEconomy.TradeOfferConfirmationMethod>();
                    x.CreateMap<TradeAsset, TradeAssetModel>();
                    x.CreateMap<TradedAsset, TradedAssetModel>();
                    x.CreateMap<TradedCurrency, TradedCurrencyModel>();
                    x.CreateMap<Trade, TradeModel>()
                        .ForMember(dest => dest.TimeTradeStarted, opts => opts.MapFrom(source => source.TimeTradeStarted.ToDateTime()))
                        .ForMember(dest => dest.TimeEscrowEnds, opts => opts.MapFrom(source => source.TimeEscrowEnds.ToDateTime()));
                    x.CreateMap<TradeOffer, TradeOfferModel>()
                        .ForMember(dest => dest.TimeCreated, opts => opts.MapFrom(source => source.TimeCreated.ToDateTime()))
                        .ForMember(dest => dest.TimeEscrowEnds, opts => opts.MapFrom(source => source.TimeEscrowEnds.ToDateTime()))
                        .ForMember(dest => dest.TimeExpiration, opts => opts.MapFrom(source => source.TimeExpiration.ToDateTime()))
                        .ForMember(dest => dest.TimeUpdated, opts => opts.MapFrom(source => source.TimeUpdated.ToDateTime()));
                    x.CreateMap<TradeHistoryResult, TradeHistoryModel>();
                    x.CreateMap<TradeOfferResult, TradeOfferResultModel>();
                    x.CreateMap<TradeOffersResult, TradeOffersResultModel>();
                });
            }

            if (mapper == null)
            {
                mapper = config.CreateMapper();
            }
        }

        public static void Reset()
        {
            config = null;
            mapper = null;
        }
    }
}