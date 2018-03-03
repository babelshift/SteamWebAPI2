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
using System.Collections.ObjectModel;
using System.Linq;

namespace SteamWebAPI2
{
    internal static class AutoMapperConfiguration
    {
        private static bool isInitialized = false;
        private static MapperConfiguration config;
        private static IMapper mapper;

        public static IMapper Mapper { get { return mapper; } }

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
                    //CreateSteamWebResponseMap<SchemaResultContainer, Steam.Models.DOTA2.SchemaModel>(x);
                    CreateSteamWebResponseMap<SchemaResultContainer, Steam.Models.TF2.SchemaModel>(x);
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
                    x.CreateMap<SchemaResultContainer, Steam.Models.TF2.SchemaModel>().ConvertUsing(
                        src => Mapper.Map<SchemaResult, Steam.Models.TF2.SchemaModel>(src.Result)
                    );

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

                    #endregion

                    #region Endpoint: DOTA2Fantasy

                    x.CreateMap<PlayerOfficialInfoResult, PlayerOfficialInfoModel>();
                    x.CreateMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>().ConvertUsing(
                        src => Mapper.Map<PlayerOfficialInfoResult, PlayerOfficialInfoModel>(src.Result)
                    );

                    x.CreateMap<ProPlayerInfo, ProPlayerInfoModel>();
                    x.CreateMap<ProPlayerLeaderboard, ProPlayerLeaderboardModel>();
                    x.CreateMap<ProPlayerListResult, ProPlayerDetailModel>();

                    #endregion

                    #region Endpoint: DOTA2Match

                    x.CreateMap<League, LeagueModel>()
                        .ForMember(dest => dest.ImageInventoryPath, opts => opts.Ignore())
                        .ForMember(dest => dest.ImageBannerPath, opts => opts.Ignore())
                        .ForMember(dest => dest.NameLocalized, opts => opts.Ignore())
                        .ForMember(dest => dest.DescriptionLocalized, opts => opts.Ignore())
                        .ForMember(dest => dest.TypeName, opts => opts.Ignore())
                        .ForMember(dest => dest.Tier, opts => opts.Ignore())
                        .ForMember(dest => dest.Location, opts => opts.Ignore());
                    x.CreateMap<LeagueResultContainer, IReadOnlyCollection<LeagueModel>>().ConvertUsing(
                        src => Mapper.Map<IList<League>, IReadOnlyCollection<LeagueModel>>(src.Result != null ? src.Result.Leagues : null)
                    );

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
                    x.CreateMap<LiveLeagueGameResultContainer, IReadOnlyCollection<LiveLeagueGameModel>>().ConvertUsing(
                        src => Mapper.Map<IList<LiveLeagueGame>, IReadOnlyCollection<LiveLeagueGameModel>>(src.Result != null ? src.Result.Games : null)
                    );

                    x.CreateMap<MatchDetailResult, MatchDetailModel>()
                        .ForMember(dest => dest.StartTime, opts => opts.MapFrom(src => src.StartTime.ToDateTime()));
                    x.CreateMap<MatchPlayer, MatchPlayerModel>();
                    x.CreateMap<MatchPlayerAbilityUpgrade, MatchPlayerAbilityUpgradeModel>();
                    x.CreateMap<MatchPickBan, MatchPickBanModel>();
                    x.CreateMap<MatchDetailResultContainer, MatchDetailModel>().ConvertUsing(
                        src => Mapper.Map<MatchDetailResult, MatchDetailModel>(src.Result)
                    );

                    x.CreateMap<MatchHistoryMatch, MatchHistoryMatchModel>();
                    x.CreateMap<MatchHistoryPlayer, MatchHistoryPlayerModel>();
                    x.CreateMap<MatchHistoryResult, MatchHistoryModel>();
                    x.CreateMap<MatchHistoryResultContainer, MatchHistoryModel>().ConvertUsing(
                        src => Mapper.Map<MatchHistoryResult, MatchHistoryModel>(src.Result)
                    );

                    x.CreateMap<MatchHistoryBySequenceNumberResult, MatchHistoryModel>()
                        .ForMember(dest => dest.NumResults, opts => opts.Ignore())
                        .ForMember(dest => dest.TotalResults, opts => opts.Ignore())
                        .ForMember(dest => dest.ResultsRemaining, opts => opts.Ignore());
                    x.CreateMap<MatchHistoryBySequenceNumberResultContainer, IReadOnlyCollection<MatchHistoryMatchModel>>().ConvertUsing(
                        src => Mapper.Map<IList<MatchHistoryMatch>, IReadOnlyCollection<MatchHistoryMatchModel>>(src.Result != null ? src.Result.Matches : null)
                    );

                    x.CreateMap<TeamInfo, TeamInfoModel>();
                    x.CreateMap<TeamInfoResultContainer, IReadOnlyCollection<TeamInfoModel>>().ConvertUsing(
                        src => Mapper.Map<IList<TeamInfo>, IReadOnlyCollection<TeamInfoModel>>(src.Result != null ? src.Result.Teams : null)
                    );

                    #endregion

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

                    #endregion

                    #region Endpoint: GCVersion

                    x.CreateMap<GameClientResult, GameClientResultModel>();
                    x.CreateMap<GameClientResultContainer, GameClientResultModel>().ConvertUsing(
                        src => Mapper.Map<GameClientResult, GameClientResultModel>(src.Result)
                    );

                    #endregion

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

                    x.CreateMap<SteamLevelResultContainer, uint?>().ConvertUsing(src =>
                    {
                        if (src.Result == null)
                        {
                            return null;
                        }
                        else
                        {
                            return src.Result.PlayerLevel;
                        }
                    });

                    x.CreateMap<OwnedGame, OwnedGameModel>()
                    .ForMember(dest => dest.PlaytimeLastTwoWeeks, opts => opts.ResolveUsing(src =>
                    {
                        if (!src.Playtime2weeks.HasValue)
                        {
                            return (TimeSpan?)null;
                        }
                        return TimeSpan.FromMinutes(src.Playtime2weeks.Value);
                    }))
                    .ForMember(dest => dest.PlaytimeForever, opts => opts.ResolveUsing(src =>
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

                    #endregion

                    #region Endpoint: SteamApps

                    x.CreateMap<SteamApp, SteamAppModel>();
                    x.CreateMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>().ConvertUsing(
                        src => Mapper.Map<IList<SteamApp>, IReadOnlyCollection<SteamAppModel>>(src.Result != null ? src.Result.Apps : null)
                    );

                    x.CreateMap<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>();
                    x.CreateMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>().ConvertUsing(
                        src => Mapper.Map<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>(src.Result)
                    );

                    #endregion

                    #region Endpoint: SteamNews

                    x.CreateMap<NewsItem, NewsItemModel>();
                    x.CreateMap<SteamNewsResult, SteamNewsResultModel>();
                    x.CreateMap<SteamNewsResultContainer, SteamNewsResultModel>().ConvertUsing(
                        src => Mapper.Map<SteamNewsResult, SteamNewsResultModel>(src.Result)
                    );

                    #endregion

                    #region Endpoint: SteamRemoteStorage

                    x.CreateMap<uint, PublishedFileVisibility>()
                        .ConvertUsing(src =>
                        {
                            return (PublishedFileVisibility)src;
                        });
                    x.CreateMap<PublishedFileDetails, PublishedFileDetailsModel>()
                        .ForMember(dest => dest.FileUrl, opts => opts.MapFrom(source => new Uri(source.FileUrl)))
                        .ForMember(dest => dest.PreviewUrl, opts => opts.MapFrom(source => new Uri(source.PreviewUrl)));
                    x.CreateMap<PublishedFileDetailsResultContainer, IReadOnlyCollection<PublishedFileDetailsModel>>()
                        .ConvertUsing(
                            src => Mapper.Map<IList<PublishedFileDetails>, IReadOnlyCollection<PublishedFileDetailsModel>>(
                                src.Result?.Result == 1 ? src.Result.Details : null)
                    );
                    x.CreateMap<PublishedFileDetailsResultContainer, PublishedFileDetailsModel>()
                        .ConvertUsing(
                            src => Mapper.Map<PublishedFileDetails, PublishedFileDetailsModel>(
                                src.Result?.Result == 1 ? src.Result.Details?.SingleOrDefault() : null)
                        );

                    x.CreateMap<UGCFileDetails, UGCFileDetailsModel>();
                    x.CreateMap<UGCFileDetailsResultContainer, UGCFileDetailsModel>().ConvertUsing(
                        src => Mapper.Map<UGCFileDetails, UGCFileDetailsModel>(src.Result)
                    );

                    #endregion

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

                    #endregion

                    #region Endpoint: SteamUserStats

                    x.CreateMap<GlobalAchievementPercentage, GlobalAchievementPercentageModel>();
                    x.CreateMap<GlobalAchievementPercentagesResultContainer, IReadOnlyCollection<GlobalAchievementPercentageModel>>().ConvertUsing(
                        src => Mapper.Map<IList<GlobalAchievementPercentage>, IReadOnlyCollection<GlobalAchievementPercentageModel>>(src.Result != null ? src.Result.AchievementPercentages : null)
                    );

                    x.CreateMap<GlobalStatsForGameResultContainer, IReadOnlyCollection<GlobalStatModel>>().ConvertUsing(
                        src => Mapper.Map<IList<GlobalStat>, IReadOnlyCollection<GlobalStatModel>>(src.Result != null ? src.Result.GlobalStats : null)
                    );

                    x.CreateMap<CurrentPlayersResultContainer, uint>().ConvertUsing(src => src.Result != null ? src.Result.PlayerCount : default(uint));

                    x.CreateMap<PlayerAchievement, PlayerAchievementModel>();
                    x.CreateMap<PlayerAchievementResult, PlayerAchievementResultModel>();
                    x.CreateMap<PlayerAchievementResultContainer, PlayerAchievementResultModel>().ConvertUsing(
                        src => Mapper.Map<PlayerAchievementResult, PlayerAchievementResultModel>(src.Result)
                    );

                    x.CreateMap<AvailableGameStats, AvailableGameStatsModel>();
                    x.CreateMap<SchemaGameAchievement, SchemaGameAchievementModel>();
                    x.CreateMap<SchemaGameStat, SchemaGameStatModel>();
                    x.CreateMap<SchemaForGameResult, SchemaForGameResultModel>();
                    x.CreateMap<SchemaForGameResultContainer, SchemaForGameResultModel>().ConvertUsing(
                        src => Mapper.Map<SchemaForGameResult, SchemaForGameResultModel>(src.Result)
                    );

                    x.CreateMap<UserStatAchievement, UserStatAchievementModel>();
                    x.CreateMap<UserStat, UserStatModel>();
                    x.CreateMap<UserStatsForGameResult, UserStatsForGameResultModel>();
                    x.CreateMap<UserStatsForGameResultContainer, UserStatsForGameResultModel>().ConvertUsing(
                        src => Mapper.Map<UserStatsForGameResult, UserStatsForGameResultModel>(src.Result)
                    );

                    #endregion

                    #region Endpoint: SteamWebAPIUtil

                    x.CreateMap<SteamServerInfo, SteamServerInfoModel>();

                    x.CreateMap<SteamInterface, SteamInterfaceModel>();
                    x.CreateMap<SteamMethod, SteamMethodModel>();
                    x.CreateMap<SteamParameter, SteamParameterModel>();
                    x.CreateMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>().ConvertUsing(
                        src => Mapper.Map<IList<SteamInterface>, IReadOnlyCollection<SteamInterfaceModel>>(src.Result != null ? src.Result.Interfaces : null)
                    );

                    #endregion

                    #region Endpoint: TFItems

                    x.CreateMap<GoldenWrench, GoldenWrenchModel>();
                    x.CreateMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>().ConvertUsing(
                        src => Mapper.Map<IList<GoldenWrench>, IReadOnlyCollection<GoldenWrenchModel>>(src.Result != null ? src.Result.GoldenWrenches : null)
                    );

                    #endregion

                    #region Endpoint: SteamEconomy

                    x.CreateMap<AssetClassAction, AssetClassActionModel>();
                    x.CreateMap<AssetClassAppDataFilter, AssetClassAppDataFilterModel>();
                    x.CreateMap<AssetClassAppData, AssetClassAppDataModel>();
                    x.CreateMap<AssetClassDescription, AssetClassDescriptionModel>();
                    x.CreateMap<AssetClassInfo, AssetClassInfoModel>();
                    x.CreateMap<AssetClassMarketAction, AssetClassMarketActionModel>();
                    x.CreateMap<AssetClassTag, AssetClassTagModel>();
                    x.CreateMap<AssetClassInfoResult, AssetClassInfoResultModel>();
                    x.CreateMap<AssetClassInfoResultContainer, AssetClassInfoResultModel>().ConvertUsing(
                        src => Mapper.Map<AssetClassInfoResult, AssetClassInfoResultModel>(src.Result)
                    );

                    x.CreateMap<AssetPrices, AssetPricesModel>();
                    x.CreateMap<Asset, AssetModel>();
                    x.CreateMap<AssetClass, AssetClassModel>();
                    x.CreateMap<AssetTags, AssetTagsModel>();
                    x.CreateMap<AssetTagIds, AssetTagIdsModel>();
                    x.CreateMap<AssetPriceResult, AssetPriceResultModel>();
                    x.CreateMap<AssetPriceResultContainer, AssetPriceResultModel>().ConvertUsing(
                        src => Mapper.Map<AssetPriceResult, AssetPriceResultModel>(src.Result)
                    );

                    #endregion

                    x.CreateMap<SchemaUrlResultContainer, string>().ConvertUsing(src => src.Result != null ? src.Result.ItemsGameUrl : null);

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
                    x.CreateMap<StoreMetaDataResultContainer, StoreMetaDataModel>().ConvertUsing(
                        src => Mapper.Map<StoreMetaDataResult, StoreMetaDataModel>(src.Result)
                    );

                    x.CreateMap<StoreStatusResultContainer, uint>().ConvertUsing(src => src.Result != null ? src.Result.StoreStatus : default(uint));

                    x.CreateMap<ServerStatusApp, ServerStatusAppModel>();
                    x.CreateMap<ServerStatusResult, ServerStatusModel>();
                    x.CreateMap<ServerStatusMatchmaking, ServerStatusMatchmakingModel>();
                    x.CreateMap<ServerStatusServices, ServerStatusServicesModel>();
                    x.CreateMap<ServerStatusDatacenter, ServerStatusDatacenterModel>();
                    x.CreateMap<ServerStatusResultContainer, ServerStatusModel>().ConvertUsing(
                        src => Mapper.Map<ServerStatusResult, ServerStatusModel>(src.Result)
                    );

                    x.CreateMap<EconItem, EconItemModel>();
                    x.CreateMap<EconItemAttribute, EconItemAttributeModel>();
                    x.CreateMap<EconItemAttributeAccountInfo, EconItemAttributeAccountInfoModel>();
                    x.CreateMap<EconItemEquipped, EconItemEquippedModel>();
                    x.CreateMap<EconItemResult, EconItemResultModel>();
                    x.CreateMap<EconItemResultContainer, EconItemResultModel>().ConvertUsing(
                        src => Mapper.Map<EconItemResult, EconItemResultModel>(src.Result)
                    );

                    #region Endpoint: SteamStore

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

                    #endregion

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
                });

            }

            if (mapper == null)
            {
                mapper = config.CreateMapper();
            }

            isInitialized = true;

#if DEBUG
            config.AssertConfigurationIsValid();
#endif
        }

        public static void Reset()
        {
            config = null;
            mapper = null;
        }
    }
}