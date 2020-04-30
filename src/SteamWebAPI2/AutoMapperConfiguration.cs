using AutoMapper;
using Steam.Models;
using Steam.Models.CSGO;
using Steam.Models.DOTA2;
using Steam.Models.GameEconomy;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamEconomy;
using Steam.Models.SteamPlayer;
using Steam.Models.TF2;
using SteamWebAPI2.Models;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Models.TF2;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
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
                    CreateSteamWebResponseMap<HeroResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.Hero>>(x);
                    CreateSteamWebResponseMap<ItemIconPathResultContainer, string>(x);
                    CreateSteamWebResponseMap<RarityResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.Rarity>>(x);
                    CreateSteamWebResponseMap<PrizePoolResultContainer, uint>(x);
                    CreateSteamWebResponseMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>(x);
                    CreateSteamWebResponseMap<ProPlayerListResult, ProPlayerDetailModel>(x);
                    CreateSteamWebResponseMap<LeagueResultContainer, IReadOnlyCollection<LeagueModel>>(x);
                    CreateSteamWebResponseMap<LiveLeagueGameResultContainer, IReadOnlyCollection<LiveLeagueGameModel>>(x);
                    CreateSteamWebResponseMap<MatchDetailResultContainer, MatchDetailModel>(x);
                    CreateSteamWebResponseMap<MatchHistoryResultContainer, MatchHistoryModel>(x);
                    CreateSteamWebResponseMap<MatchHistoryBySequenceNumberResultContainer, IReadOnlyCollection<MatchHistoryMatchModel>>(x);
                    CreateSteamWebResponseMap<TeamInfoResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>(x);
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
                    CreateSteamWebResponseMap<TradeHoldDurationsResultContainer, TradeHoldDurationsResultModel>(x);

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
                    x.AddProfile<GCVersionProfile>();
                    x.AddProfile<SteamAppsProfile>();
                    x.AddProfile<SteamWebAPIUtilProfile>();
                    x.AddProfile<TFItemsProfile>();
                    x.AddProfile<SteamNewsProfile>();
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

        public static void Reset()
        {
            config = null;
            Mapper = null;
        }
    }
}