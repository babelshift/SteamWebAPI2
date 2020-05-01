using System.Collections.Generic;
using AutoMapper;
using Steam.Models;
using Steam.Models.CSGO;
using Steam.Models.DOTA2;
using Steam.Models.GameEconomy;
using Steam.Models.GameServers;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamEconomy;
using Steam.Models.SteamPlayer;
using Steam.Models.TF2;
using SteamWebAPI2.Models;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Models.GameServers;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Models.TF2;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Mappings
{
    public class SteamWebResponseProfile : Profile
    {
        public SteamWebResponseProfile()
        {
            CreateSteamWebResponseMap<ServerStatusResultContainer, ServerStatusModel>();
            CreateSteamWebResponseMap<GameItemResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.GameItem>>();
            CreateSteamWebResponseMap<HeroResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.Hero>>();
            CreateSteamWebResponseMap<ItemIconPathResultContainer, string>();
            CreateSteamWebResponseMap<RarityResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.Rarity>>();
            CreateSteamWebResponseMap<PrizePoolResultContainer, uint>();
            CreateSteamWebResponseMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>();
            CreateSteamWebResponseMap<ProPlayerListResult, ProPlayerDetailModel>();
            CreateSteamWebResponseMap<LeagueResultContainer, IReadOnlyCollection<LeagueModel>>();
            CreateSteamWebResponseMap<LiveLeagueGameResultContainer, IReadOnlyCollection<LiveLeagueGameModel>>();
            CreateSteamWebResponseMap<MatchDetailResultContainer, MatchDetailModel>();
            CreateSteamWebResponseMap<MatchHistoryResultContainer, MatchHistoryModel>();
            CreateSteamWebResponseMap<MatchHistoryBySequenceNumberResultContainer, IReadOnlyCollection<MatchHistoryMatchModel>>();
            CreateSteamWebResponseMap<TeamInfoResultContainer, IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>();
            CreateSteamWebResponseMap<EconItemResultContainer, EconItemResultModel>();
            CreateSteamWebResponseMap<SchemaUrlResultContainer, string>();
            CreateSteamWebResponseMap<StoreMetaDataResultContainer, StoreMetaDataModel>();
            CreateSteamWebResponseMap<StoreStatusResultContainer, uint>();
            CreateSteamWebResponseMap<TradeHistoryResultContainer, Steam.Models.SteamEconomy.TradeHistoryModel>();
            CreateSteamWebResponseMap<TradeOffersResultContainer, Steam.Models.SteamEconomy.TradeOffersResultModel>();
            CreateSteamWebResponseMap<TradeOfferResultContainer, Steam.Models.SteamEconomy.TradeOfferResultModel>();
            CreateSteamWebResponseMap<GameClientResultContainer, GameClientResultModel>();
            CreateSteamWebResponseMap<PlayingSharedGameResultContainer, ulong?>();
            CreateSteamWebResponseMap<CommunityBadgeProgressResultContainer, IReadOnlyCollection<BadgeQuestModel>>();
            CreateSteamWebResponseMap<BadgesResultContainer, BadgesResultModel>();
            CreateSteamWebResponseMap<SteamLevelResultContainer, uint?>();
            CreateSteamWebResponseMap<OwnedGamesResultContainer, OwnedGamesResultModel>();
            CreateSteamWebResponseMap<RecentlyPlayedGameResultContainer, RecentlyPlayedGamesResultModel>();
            CreateSteamWebResponseMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>();
            CreateSteamWebResponseMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>();
            CreateSteamWebResponseMap<AssetClassInfoResultContainer, AssetClassInfoResultModel>();
            CreateSteamWebResponseMap<AssetPriceResultContainer, AssetPriceResultModel>();
            CreateSteamWebResponseMap<SteamNewsResultContainer, SteamNewsResultModel>();
            CreateSteamWebResponseMap<PublishedFileDetailsResultContainer, IReadOnlyCollection<PublishedFileDetailsModel>>();
            CreateSteamWebResponseMap<PublishedFileDetailsResultContainer, PublishedFileDetailsModel>();
            CreateSteamWebResponseMap<UGCFileDetailsResultContainer, UGCFileDetailsModel>();
            CreateSteamWebResponseMap<PlayerSummaryResultContainer, PlayerSummaryModel>();
            CreateSteamWebResponseMap<PlayerSummaryResultContainer, IReadOnlyCollection<PlayerSummaryModel>>();
            CreateSteamWebResponseMap<FriendsListResultContainer, IReadOnlyCollection<FriendModel>>();
            CreateSteamWebResponseMap<PlayerBansContainer, IReadOnlyCollection<PlayerBansModel>>();
            CreateSteamWebResponseMap<UserGroupListResultContainer, IReadOnlyCollection<ulong>>();
            CreateSteamWebResponseMap<ResolveVanityUrlResultContainer, ulong>();
            CreateSteamWebResponseMap<GlobalAchievementPercentagesResultContainer, IReadOnlyCollection<GlobalAchievementPercentageModel>>();
            CreateSteamWebResponseMap<GlobalStatsForGameResultContainer, IReadOnlyCollection<GlobalStatModel>>();
            CreateSteamWebResponseMap<CurrentPlayersResultContainer, uint>();
            CreateSteamWebResponseMap<PlayerAchievementResultContainer, PlayerAchievementResultModel>();
            CreateSteamWebResponseMap<SchemaForGameResultContainer, SchemaForGameResultModel>();
            CreateSteamWebResponseMap<UserStatsForGameResultContainer, UserStatsForGameResultModel>();
            CreateSteamWebResponseMap<SteamServerInfo, SteamServerInfoModel>();
            CreateSteamWebResponseMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>();
            CreateSteamWebResponseMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>();
            CreateSteamWebResponseMap<GameMapsPlaytimeContainer, IEnumerable<GameMapsPlaytimeModel>>();
            CreateSteamWebResponseMap<AccountListContainer, AccountListModel>();
            CreateSteamWebResponseMap<CreateAccountContainer, CreateAccountModel>();
            CreateSteamWebResponseMap<ResetLoginTokenContainer, string>();
            CreateSteamWebResponseMap<AccountPublicInfoContainer, AccountPublicInfoModel>();
            CreateSteamWebResponseMap<QueryLoginTokenContainer, QueryLoginTokenModel>();
            CreateSteamWebResponseMap<TradeHoldDurationsResultContainer, TradeHoldDurationsResultModel>();

        }

        private SteamWebResponse<TDestination> ConstructSteamWebResponse<TSource, TDestination>(ISteamWebResponse<TSource> response, ResolutionContext context)
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
                newResponse.Data = context.Mapper.Map<TSource, TDestination>(response.Data);
            }

            return newResponse;
        }

        private void CreateSteamWebResponseMap<TSource, TDestination>()
        {
            CreateMap<ISteamWebResponse<TSource>, ISteamWebResponse<TDestination>>()
                .ConvertUsing((src, dest, context) => ConstructSteamWebResponse<TSource, TDestination>(src, context));
        }
    }
}