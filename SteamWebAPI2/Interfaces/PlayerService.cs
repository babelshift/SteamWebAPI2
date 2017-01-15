using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Exceptions;

namespace SteamWebAPI2.Interfaces
{
    public class PlayerService : IPlayerService
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public PlayerService(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "IPlayerService")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a message which indicates if a player is playing a shared game (from their shared Steam library).
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ulong?> IsPlayingSharedGameAsync(ulong steamId, uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(appId, "appid_playing");

            var playingSharedGameResult = await steamWebInterface.GetAsync<PlayingSharedGameResultContainer>("IsPlayingSharedGame", 1, parameters);

            if (playingSharedGameResult == null || playingSharedGameResult.Result == null)
            {
                return null;
            }

            return playingSharedGameResult.Result.LenderSteamId;
        }

        /// <summary>
        /// Returns a collection of badge meta data which indicates the progress towards a badge for a specific user.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="badgeId"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<BadgeQuestModel>> GetCommunityBadgeProgressAsync(ulong steamId, uint? badgeId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(badgeId, "badgeid");
            var badgeProgressResult = await steamWebInterface.GetAsync<CommunityBadgeProgressResultContainer>("GetCommunityBadgeProgress", 1, parameters);

            if(badgeProgressResult == null || badgeProgressResult.Result == null)
            {
                return null;
            }

            var badgeProgressModels = AutoMapperConfiguration.Mapper.Map<IList<BadgeQuest>, IList<BadgeQuestModel>>(badgeProgressResult.Result.Quests);

            return new ReadOnlyCollection<BadgeQuestModel>(badgeProgressModels);
        }

        /// <summary>
        /// Returns a collection of all badges that a user has interacted with on Steam.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<BadgesResultModel> GetBadgesAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var badgesResult = await steamWebInterface.GetAsync<BadgesResultContainer>("GetBadges", 1, parameters);

            if(badgesResult == null || badgesResult.Result == null)
            {
                return null;
            }

            var badgesResultModel = AutoMapperConfiguration.Mapper.Map<BadgesResult, BadgesResultModel>(badgesResult.Result);

            return badgesResultModel;
        }

        /// <summary>
        /// Returns the Steam Level of a specific Steam User.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<uint?> GetSteamLevelAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamLevelResult = await steamWebInterface.GetAsync<SteamLevelResultContainer>("GetSteamLevel", 1, parameters);

            if (steamLevelResult == null || steamLevelResult.Result == null)
            {
                return null;
            }

            return steamLevelResult.Result.PlayerLevel;
        }

        /// <summary>
        /// Returns a collection of games and game meta data that are owned by a specific Steam User.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="includeAppInfo"></param>
        /// <param name="includeFreeGames"></param>
        /// <param name="appIdsToFilter"></param>
        /// <returns></returns>
        public async Task<OwnedGamesResultModel> GetOwnedGamesAsync(ulong steamId, bool? includeAppInfo = null, bool? includeFreeGames = null, IReadOnlyCollection<uint> appIdsToFilter = null)
        {
            int? includeAppInfoBit = 0;
            if (includeAppInfo.HasValue) { includeAppInfoBit = includeAppInfo.Value ? 1 : 0; }

            int? includeFreeGamesBit = 0;
            if (includeFreeGames.HasValue) { includeFreeGamesBit = includeFreeGames.Value ? 1 : 0; }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(includeFreeGamesBit, "include_played_Free_games");
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(includeAppInfoBit, "include_appinfo");

            if (appIdsToFilter != null)
            {
                string appIdsDelimited = String.Join(",", appIdsToFilter);
                parameters.AddIfHasValue(appIdsDelimited, "appids_filter");
            }

            var ownedGamesResult = await steamWebInterface.GetAsync<OwnedGamesResultContainer>("GetOwnedGames", 1, parameters);

            if(ownedGamesResult == null || ownedGamesResult.Result == null)
            {
                return null;
            }

            // for some reason, some games have trailing spaces in the result
            if (ownedGamesResult.Result.OwnedGames != null)
            {
                foreach (var ownedGame in ownedGamesResult.Result.OwnedGames)
                {
                    if (!String.IsNullOrWhiteSpace(ownedGame.Name))
                    {
                        ownedGame.Name = ownedGame.Name.Trim();
                    }
                }
            }

            var ownedGamesResultModel = AutoMapperConfiguration.Mapper.Map<OwnedGamesResult, OwnedGamesResultModel>(ownedGamesResult.Result);
            
            return ownedGamesResultModel;
        }

        /// <summary>
        /// Returns a collection of recently played games and game meta data by a specific Steam User.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<RecentlyPlayedGamesResultModel> GetRecentlyPlayedGamesAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var recentlyPlayedGamesResult = await steamWebInterface.GetAsync<RecentlyPlayedGameResultContainer>("GetRecentlyPlayedGames", 1, parameters);

            if (recentlyPlayedGamesResult == null || recentlyPlayedGamesResult.Result == null)
            {
                return null;
            }

            var recentlyPlayedGamesResultModel = AutoMapperConfiguration.Mapper.Map<RecentlyPlayedGameResult, RecentlyPlayedGamesResultModel>(recentlyPlayedGamesResult.Result);

            return recentlyPlayedGamesResultModel;
        }
    }
}