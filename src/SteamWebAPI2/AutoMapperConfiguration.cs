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
using System.Collections.Generic;
using System.Linq;
using SteamWebAPI2.Models.GameServers;
using Steam.Models.GameServers;
using SteamWebAPI2.Mappings;

namespace SteamWebAPI2
{
    internal static class AutoMapperConfiguration
    {
        private static bool isInitialized = false;
        private static MapperConfiguration config;
        public static IMapper Mapper { get; private set; }

        private static SteamWebResponse<TDestination> ConstructSteamWebResponse<TSource, TDestination>(ISteamWebResponse<TSource> response)
        {
            if (response == null)
            {
                return null;
            }

            var newResponse = new SteamWebResponse<TDestination>();

            newResponse.ContentLength = response.ContentLength;
            newResponse.ContentType = response.ContentType;
            newResponse.ContentTypeCharSet = response.ContentTypeCharSet;
            newResponse.Expires = response.Expires;
            newResponse.LastModified = response.LastModified;

            if (response.Data != null)
            {
                newResponse.Data = Mapper.Map<TSource, TDestination>(response.Data);
            }

            return newResponse;
        }

        private static void CreateSteamWebResponseMap<TSource, TDestination>(IMapperConfigurationExpression config)
        {
            config.CreateMap<ISteamWebResponse<TSource>, ISteamWebResponse<TDestination>>()
                .ConstructUsing(src => ConstructSteamWebResponse<TSource, TDestination>(src));
        }

        public static void Initialize()
        {
            if (isInitialized)
            {
                return;
            }

            if (config == null)
            {
                config = new MapperConfiguration(x =>
                {
                    CreateSteamWebResponseMap<ServerStatusResultContainer, ServerStatusModel>(x);
                    CreateSteamWebResponseMap<GameItemResultContainer, IReadOnlyCollection<GameItemModel>>(x);
                    CreateSteamWebResponseMap<HeroResultContainer, IReadOnlyCollection<HeroModel>>(x);
                    CreateSteamWebResponseMap<ItemIconPathResultContainer, string>(x);
                    CreateSteamWebResponseMap<RarityResultContainer, IReadOnlyCollection<RarityModel>>(x);
                    CreateSteamWebResponseMap<PrizePoolResultContainer, uint>(x);
                    CreateSteamWebResponseMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>(x);
                    CreateSteamWebResponseMap<ProPlayerListResult, ProPlayerDetailModel>(x);
                    CreateSteamWebResponseMap<LeagueResultContainer, IReadOnlyCollection<LeagueModel>>(x);
                    CreateSteamWebResponseMap<LiveLeagueGameResultContainer, IReadOnlyCollection<LiveLeagueGameModel>>(x);
                    CreateSteamWebResponseMap<MatchDetailResultContainer, MatchDetailModel>(x);
                    CreateSteamWebResponseMap<MatchHistoryResultContainer, MatchHistoryModel>(x);
                    CreateSteamWebResponseMap<MatchHistoryBySequenceNumberResultContainer, IReadOnlyCollection<MatchHistoryMatchModel>>(x);
                    CreateSteamWebResponseMap<TeamInfoResultContainer, IReadOnlyCollection<TeamInfoModel>>(x);
                    CreateSteamWebResponseMap<EconItemResultContainer, EconItemResultModel>(x);
                    CreateSteamWebResponseMap<SchemaUrlResultContainer, string>(x);
                    CreateSteamWebResponseMap<StoreMetaDataResultContainer, StoreMetaDataModel>(x);
                    CreateSteamWebResponseMap<StoreStatusResultContainer, uint>(x);
                    CreateSteamWebResponseMap<TradeHistoryResultContainer, Steam.Models.SteamEconomy.TradeHistoryModel>(x);
                    CreateSteamWebResponseMap<TradeOffersResultContainer, Steam.Models.SteamEconomy.TradeOffersResultModel>(x);
                    CreateSteamWebResponseMap<TradeOfferResultContainer, Steam.Models.SteamEconomy.TradeOfferResultModel>(x);
                    CreateSteamWebResponseMap<GameClientResultContainer, GameClientResultModel>(x);
                    CreateSteamWebResponseMap<PlayingSharedGameResultContainer, ulong?>(x);
                    CreateSteamWebResponseMap<CommunityBadgeProgressResultContainer, IReadOnlyCollection<BadgeQuestModel>>(x);
                    CreateSteamWebResponseMap<BadgesResultContainer, BadgesResultModel>(x);
                    CreateSteamWebResponseMap<SteamLevelResultContainer, uint?>(x);
                    CreateSteamWebResponseMap<OwnedGamesResultContainer, OwnedGamesResultModel>(x);
                    CreateSteamWebResponseMap<RecentlyPlayedGameResultContainer, RecentlyPlayedGamesResultModel>(x);
                    CreateSteamWebResponseMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>(x);
                    CreateSteamWebResponseMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>(x);
                    CreateSteamWebResponseMap<AssetClassInfoResultContainer, AssetClassInfoResultModel>(x);
                    CreateSteamWebResponseMap<AssetPriceResultContainer, AssetPriceResultModel>(x);
                    CreateSteamWebResponseMap<SteamNewsResultContainer, SteamNewsResultModel>(x);
                    CreateSteamWebResponseMap<PublishedFileDetailsResultContainer, IReadOnlyCollection<PublishedFileDetailsModel>>(x);
                    CreateSteamWebResponseMap<PublishedFileDetailsResultContainer, PublishedFileDetailsModel>(x);
                    CreateSteamWebResponseMap<UGCFileDetailsResultContainer, UGCFileDetailsModel>(x);
                    CreateSteamWebResponseMap<PlayerSummaryResultContainer, PlayerSummaryModel>(x);
                    CreateSteamWebResponseMap<PlayerSummaryResultContainer, IReadOnlyCollection<PlayerSummaryModel>>(x);
                    CreateSteamWebResponseMap<FriendsListResultContainer, IReadOnlyCollection<FriendModel>>(x);
                    CreateSteamWebResponseMap<PlayerBansContainer, IReadOnlyCollection<PlayerBansModel>>(x);
                    CreateSteamWebResponseMap<UserGroupListResultContainer, IReadOnlyCollection<ulong>>(x);
                    CreateSteamWebResponseMap<ResolveVanityUrlResultContainer, ulong>(x);
                    CreateSteamWebResponseMap<GlobalAchievementPercentagesResultContainer, IReadOnlyCollection<GlobalAchievementPercentageModel>>(x);
                    CreateSteamWebResponseMap<GlobalStatsForGameResultContainer, IReadOnlyCollection<GlobalStatModel>>(x);
                    CreateSteamWebResponseMap<CurrentPlayersResultContainer, uint>(x);
                    CreateSteamWebResponseMap<PlayerAchievementResultContainer, PlayerAchievementResultModel>(x);
                    CreateSteamWebResponseMap<SchemaForGameResultContainer, SchemaForGameResultModel>(x);
                    CreateSteamWebResponseMap<UserStatsForGameResultContainer, UserStatsForGameResultModel>(x);
                    CreateSteamWebResponseMap<SteamServerInfo, SteamServerInfoModel>(x);
                    CreateSteamWebResponseMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>(x);
                    CreateSteamWebResponseMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>(x);
                    CreateSteamWebResponseMap<GameMapsPlaytimeContainer, IEnumerable<GameMapsPlaytimeModel>>(x);
                    CreateSteamWebResponseMap<AccountListContainer, AccountListModel>(x);
                    CreateSteamWebResponseMap<CreateAccountContainer, CreateAccountModel>(x);
                    CreateSteamWebResponseMap<ResetLoginTokenContainer, string>(x);
                    CreateSteamWebResponseMap<AccountPublicInfoContainer, AccountPublicInfoModel>(x);
                    CreateSteamWebResponseMap<QueryLoginTokenContainer, QueryLoginTokenModel>(x);

                    #region Endpoint: DOTA2Econ

                    x.CreateMap<Hero, HeroModel>();
                    x.CreateMap<HeroResultContainer, IReadOnlyCollection<HeroModel>>().ConvertUsing(
                        src => Mapper.Map<IList<Hero>, IReadOnlyCollection<HeroModel>>(src.Result != null ? src.Result.Heroes : null)
                    );

                    x.CreateMap<GameItem, GameItemModel>();
                    x.CreateMap<GameItemResultContainer, IReadOnlyCollection<GameItemModel>>().ConvertUsing(
                        src => Mapper.Map<IList<GameItem>, IReadOnlyCollection<GameItemModel>>(src.Result != null ? src.Result.Items : null)
                    );

                    x.CreateMap<ItemIconPathResultContainer, string>().ConvertUsing(src => src.Result != null ? src.Result.Path : null);

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

                    // TODO: Rework the way Schema models are used for different games (TF2 / DOTA2)
                    //x.CreateMap<SchemaQualities, Steam.Models.DOTA2.SchemaQualityModel>()
                    //    .ForMember(dest => dest.Name, opts => opts.Ignore())
                    //    .ForMember(dest => dest.Value, opts => opts.Ignore())
                    //    .ForMember(dest => dest.HexColor, opts => opts.Ignore());
                    //x.CreateMap<SchemaResult, Steam.Models.DOTA2.SchemaModel>()
                    //    .ForMember(dest => dest.GameInfo, opts => opts.Ignore())
                    //    .ForMember(dest => dest.Rarities, opts => opts.Ignore())
                    //    .ForMember(dest => dest.Colors, opts => opts.Ignore())
                    //    .ForMember(dest => dest.Prefabs, opts => opts.Ignore())
                    //    .ForMember(dest => dest.ItemAutographs, opts => opts.Ignore());
                    //x.CreateMap<SchemaResultContainer, Steam.Models.DOTA2.SchemaModel>().ConvertUsing(
                    //    src => Mapper.Map<SchemaResult, Steam.Models.DOTA2.SchemaModel>(src.Result)
                    //);

                    x.CreateMap<Rarity, RarityModel>();
                    x.CreateMap<RarityResultContainer, IReadOnlyCollection<RarityModel>>().ConvertUsing(
                        src => Mapper.Map<IList<Rarity>, IReadOnlyCollection<RarityModel>>(src.Result != null ? src.Result.Rarities : null)
                    );

                    x.CreateMap<PrizePoolResultContainer, uint>().ConvertUsing(src => src.Result != null ? src.Result.PrizePool : default(uint));

                    #endregion Endpoint: DOTA2Econ

                    #region Endpoint: DOTA2Fantasy

                    x.CreateMap<PlayerOfficialInfoResult, PlayerOfficialInfoModel>();
                    x.CreateMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>().ConvertUsing(
                        src => Mapper.Map<PlayerOfficialInfoResult, PlayerOfficialInfoModel>(src.Result)
                    );

                    x.CreateMap<ProPlayerInfo, ProPlayerInfoModel>();
                    x.CreateMap<ProPlayerLeaderboard, ProPlayerLeaderboardModel>();
                    x.CreateMap<ProPlayerListResult, ProPlayerDetailModel>();

                    #endregion Endpoint: DOTA2Fantasy

                    #region Endpoint: DOTA2Match

                    x.AddProfile<DOTA2MatchProfile>();

                    #endregion Endpoint: DOTA2Match

                    #region Endpoint: EconService

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
                    x.CreateMap<TradeHistoryResultContainer, TradeHistoryModel>().ConvertUsing(
                        src => Mapper.Map<TradeHistoryResult, TradeHistoryModel>(src.Result)
                    );
                    x.CreateMap<TradeOfferResultContainer, TradeOfferResultModel>().ConvertUsing(
                        src => Mapper.Map<TradeOfferResult, TradeOfferResultModel>(src.Result)
                    );
                    x.CreateMap<TradeOffersResultContainer, TradeOffersResultModel>().ConvertUsing(
                        src => Mapper.Map<TradeOffersResult, TradeOffersResultModel>(src.Result)
                    );

                    #endregion Endpoint: EconService

                    #region Endpoint: GCVersion

                    x.CreateMap<GameClientResult, GameClientResultModel>();
                    x.CreateMap<GameClientResultContainer, GameClientResultModel>().ConvertUsing(
                        src => Mapper.Map<GameClientResult, GameClientResultModel>(src.Result)
                    );

                    #endregion Endpoint: GCVersion

                    #region Endpoint: PlayerService

                    x.CreateMap<PlayingSharedGameResultContainer, ulong?>()
                        .ConvertUsing(src => src.Result != null ? src.Result.LenderSteamId : null);

                    x.CreateMap<CommunityBadgeProgressResultContainer, IReadOnlyCollection<BadgeQuestModel>>().ConvertUsing(
                        src => Mapper.Map<IList<BadgeQuest>, IReadOnlyCollection<BadgeQuestModel>>(src.Result != null ? src.Result.Quests : null)
                    );

                    x.CreateMap<Badge, BadgeModel>();
                    x.CreateMap<BadgeQuest, BadgeQuestModel>();
                    x.CreateMap<BadgesResult, BadgesResultModel>();
                    x.CreateMap<BadgesResultContainer, BadgesResultModel>().ConvertUsing(
                        src => Mapper.Map<BadgesResult, BadgesResultModel>(src.Result)
                    );

                    x.CreateMap<SteamLevelResultContainer, uint?>().ConvertUsing((src, dest) =>
                    {
                        if (src.Result == null) { return null; }
                        else { return src.Result.PlayerLevel; }
                    });

                    x.CreateMap<OwnedGame, OwnedGameModel>()
                    .ForMember(dest => dest.PlaytimeLastTwoWeeks, opts => opts.MapFrom((src, dest) =>
                    {
                        if (!src.Playtime2weeks.HasValue)
                        {
                            return (TimeSpan?)null;
                        }
                        return TimeSpan.FromMinutes(src.Playtime2weeks.Value);
                    }))
                    .ForMember(dest => dest.PlaytimeForever, opts => opts.MapFrom((src, dest) =>
                    {
                        return TimeSpan.FromMinutes(src.PlaytimeForever);
                    }));
                    x.CreateMap<OwnedGamesResult, OwnedGamesResultModel>();
                    x.CreateMap<OwnedGamesResultContainer, OwnedGamesResultModel>().ConvertUsing(
                        src => Mapper.Map<OwnedGamesResult, OwnedGamesResultModel>(src.Result)
                    );

                    x.CreateMap<RecentlyPlayedGame, RecentlyPlayedGameModel>();
                    x.CreateMap<RecentlyPlayedGameResult, RecentlyPlayedGamesResultModel>();
                    x.CreateMap<RecentlyPlayedGameResultContainer, RecentlyPlayedGamesResultModel>().ConvertUsing(
                        src => Mapper.Map<RecentlyPlayedGameResult, RecentlyPlayedGamesResultModel>(src.Result)
                    );

                    #endregion Endpoint: PlayerService

                    #region Endpoint: SteamApps

                    x.CreateMap<SteamApp, SteamAppModel>();
                    x.CreateMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>().ConvertUsing(
                        src => Mapper.Map<IList<SteamApp>, IReadOnlyCollection<SteamAppModel>>(src.Result != null ? src.Result.Apps : null)
                    );

                    x.CreateMap<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>();
                    x.CreateMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>().ConvertUsing(
                        src => Mapper.Map<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>(src.Result)
                    );

                    #endregion Endpoint: SteamApps

                    #region Endpoint: SteamNews

                    x.CreateMap<NewsItem, NewsItemModel>();
                    x.CreateMap<SteamNewsResult, SteamNewsResultModel>();
                    x.CreateMap<SteamNewsResultContainer, SteamNewsResultModel>().ConvertUsing(
                        src => Mapper.Map<SteamNewsResult, SteamNewsResultModel>(src.Result)
                    );

                    #endregion Endpoint: SteamNews

                    #region Endpoint: SteamRemoteStorage

                    x.CreateMap<uint, PublishedFileVisibility>()
                        .ConvertUsing((src, dest) =>
                        {
                            return (PublishedFileVisibility)src;
                        });
                    x.CreateMap<PublishedFileDetails, PublishedFileDetailsModel>()
                        .ForMember(dest => dest.FileUrl, opts => opts.MapFrom(source => new Uri(source.FileUrl)))
                        .ForMember(dest => dest.PreviewUrl, opts => opts.MapFrom(source => new Uri(source.PreviewUrl)));
                    x.CreateMap<PublishedFileDetailsResultContainer, IReadOnlyCollection<PublishedFileDetailsModel>>()
                        .ConvertUsing(
                            (src, dest) => Mapper.Map<IList<PublishedFileDetails>, IReadOnlyCollection<PublishedFileDetailsModel>>(
                                src.Result?.Result == 1 ? src.Result.Details : null)
                    );
                    x.CreateMap<PublishedFileDetailsResultContainer, PublishedFileDetailsModel>()
                        .ConvertUsing(
                            (src, dest) => Mapper.Map<PublishedFileDetails, PublishedFileDetailsModel>(
                                src.Result?.Result == 1 ? src.Result.Details?.SingleOrDefault() : null)
                        );

                    x.CreateMap<UGCFileDetails, UGCFileDetailsModel>();
                    x.CreateMap<UGCFileDetailsResultContainer, UGCFileDetailsModel>().ConvertUsing(
                        src => Mapper.Map<UGCFileDetails, UGCFileDetailsModel>(src.Result)
                    );

                    #endregion Endpoint: SteamRemoteStorage

                    #region Endpoint: SteamUser

                    x.CreateMap<PlayerSummary, PlayerSummaryModel>();
                    x.CreateMap<PlayerSummaryResultContainer, PlayerSummaryModel>().ConvertUsing(
                        src => Mapper.Map<PlayerSummary, PlayerSummaryModel>(src.Result != null ? src.Result.Players[0] : null)
                    );
                    x.CreateMap<PlayerSummaryResultContainer, IReadOnlyCollection<PlayerSummaryModel>>().ConvertUsing(
                        src => Mapper.Map<IList<PlayerSummary>, IReadOnlyCollection<PlayerSummaryModel>>(src.Result != null ? src.Result.Players : null)
                    );

                    x.CreateMap<Friend, FriendModel>();
                    x.CreateMap<FriendsListResultContainer, IReadOnlyCollection<FriendModel>>().ConvertUsing(
                        src => Mapper.Map<IList<Friend>, IReadOnlyCollection<FriendModel>>(src.Result != null ? src.Result.Friends : null)
                    );

                    x.CreateMap<PlayerBans, PlayerBansModel>();
                    x.CreateMap<PlayerBansContainer, IReadOnlyCollection<PlayerBansModel>>().ConvertUsing(
                        src => Mapper.Map<IList<PlayerBans>, IReadOnlyCollection<PlayerBansModel>>(src.PlayerBans)
                    );

                    x.CreateMap<UserGroupGid, ulong>().ConvertUsing(src => src.Gid);

                    x.CreateMap<UserGroupListResultContainer, IReadOnlyCollection<ulong>>().ConvertUsing(
                        src => Mapper.Map<IList<UserGroupGid>, IReadOnlyCollection<ulong>>(src.Result != null ? src.Result.Groups : null)
                    );

                    x.CreateMap<ResolveVanityUrlResultContainer, ulong>().ConvertUsing(src => src.Result != null ? src.Result.SteamId : default(ulong));

                    #endregion Endpoint: SteamUser

                    #region Endpoint: SteamUserStats

                    x.AddProfile<SteamUserStatsProfile>();

                    #endregion Endpoint: SteamUserStats

                    #region Endpoint: SteamWebAPIUtil

                    x.CreateMap<SteamServerInfo, SteamServerInfoModel>();

                    x.CreateMap<SteamInterface, SteamInterfaceModel>();
                    x.CreateMap<SteamMethod, SteamMethodModel>();
                    x.CreateMap<SteamParameter, SteamParameterModel>();
                    x.CreateMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>().ConvertUsing(
                        src => Mapper.Map<IList<SteamInterface>, IReadOnlyCollection<SteamInterfaceModel>>(src.Result != null ? src.Result.Interfaces : null)
                    );

                    #endregion Endpoint: SteamWebAPIUtil

                    #region Endpoint: TFItems

                    x.CreateMap<GoldenWrench, GoldenWrenchModel>();
                    x.CreateMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>().ConvertUsing(
                        src => Mapper.Map<IList<GoldenWrench>, IReadOnlyCollection<GoldenWrenchModel>>(src.Result != null ? src.Result.GoldenWrenches : null)
                    );

                    #endregion Endpoint: TFItems

                    #region Endpoint: SteamEconomy

                    x.AddProfile<SteamEconomyProfile>();

                    #endregion Endpoint: SteamEconomy

                    #region Endpoint: SteamStore

                    x.AddProfile<SteamStoreProfile>();

                    #endregion Endpoint: SteamStore

                    x.AddProfile<SteamProfileProfile>();
                    
                    #region Endpoint: GameServers

                    x.AddProfile<GameServersProfile>();

                    #endregion
                });
            }

            if (Mapper == null)
            {
                Mapper = config.CreateMapper();
            }

            isInitialized = true;

#if DEBUG
            config.AssertConfigurationIsValid();
#endif
        }

        public static void Reset()
        {
            config = null;
            Mapper = null;
        }
    }
}