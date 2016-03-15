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

namespace SteamWebAPI2
{
    internal static class AutoMapperConfiguration
    {
        private static MapperConfiguration config;
        private static IMapper mapper;

        public static IMapper Mapper {  get { return mapper; } }

        public static void Initialize()
        {
            if (config == null)
            {
                config = new MapperConfiguration(x =>
                {
                    x.CreateMap<SchemaResult, SchemaModel>();
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