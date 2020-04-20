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

                    x.AddProfile<DOTA2EconProfile>();
                    x.AddProfile<DOTA2FantasyProfile>();
                    x.AddProfile<DOTA2MatchProfile>();
                    x.AddProfile<EconServiceProfile>();
                    x.AddProfile<SteamEconomyProfile>();
                    x.AddProfile<SteamStoreProfile>();
                    x.AddProfile<SteamProfileProfile>();
                    x.AddProfile<GameServersProfile>();
                    x.AddProfile<PlayerServiceProfile>();
                    x.AddProfile<SteamRemoteStorageProfile>();
                    x.AddProfile<SteamUserProfile>();
                    x.AddProfile<SteamUserStatsProfile>();

                    #region Endpoint: GCVersion

                    x.CreateMap<GameClientResult, GameClientResultModel>();
                    x.CreateMap<GameClientResultContainer, GameClientResultModel>().ConvertUsing(
                        src => Mapper.Map<GameClientResult, GameClientResultModel>(src.Result)
                    );

                    #endregion Endpoint: GCVersion


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