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

        public async Task<RecentlyPlayedGameResult> GetRecentlyPlayedGamesAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            var recentlyPlayedGameResult = await CallMethodAsync<RecentlyPlayedGameResultContainer>("GetRecentlyPlayedGames", 1, parameters);
            return recentlyPlayedGameResult.Result;
        }
    }
}
