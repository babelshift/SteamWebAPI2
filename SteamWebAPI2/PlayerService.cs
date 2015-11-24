using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class PlayerService : SteamWebInterface
    {
        public PlayerService(string steamWebApiKey)
            : base(steamWebApiKey, "IPlayerService")
        {
        }

        public async Task<BadgesResult> GetBadgesAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            var badgesResult = await CallMethodAsync<BadgesResultContainer>("GetBadges", 1, parameters);
            return badgesResult.Result;
        }

        public async Task<int> GetSteamLevelAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            var steamLevelResult = await CallMethodAsync<SteamLevelResultContainer>("GetSteamLevel", 1, parameters);
            return steamLevelResult.Result.PlayerLevel;
        }

        public async Task<OwnedGamesResult> GetOwnedGamesAsync(long steamId, bool? includeAppInfo = null, bool? includeFreeGames = null, IReadOnlyCollection<int> appIdsToFilter = null)
        {
            int? includeAppInfoBit = 0;
            if (includeAppInfo.HasValue) { includeAppInfoBit = includeAppInfo.Value ? 1 : 0; }

            int? includeFreeGamesBit = 0;
            if (includeFreeGames.HasValue) { includeFreeGamesBit = includeFreeGames.Value ? 1 : 0; }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            AddToParametersIfHasValue("include_appinfo", includeAppInfoBit, parameters);
            AddToParametersIfHasValue("include_played_Free_games", includeFreeGamesBit, parameters);

            if (appIdsToFilter != null)
            {
                string appIdsDelimited = String.Join(",", appIdsToFilter);
                AddToParametersIfHasValue("appids_filter", appIdsDelimited, parameters);
            }

            var ownedGamesResult = await CallMethodAsync<OwnedGamesResultContainer>("GetOwnedGames", 1, parameters);
            return ownedGamesResult.Result;
        }

        public async Task<RecentlyPlayedGameResult> GetRecentlyPlayedGamesAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            var recentlyPlayedGameResult = await CallMethodAsync<RecentlyPlayedGameResultContainer>("GetRecentlyPlayedGames", 1, parameters);
            return recentlyPlayedGameResult.Result;
        }
    }
}
