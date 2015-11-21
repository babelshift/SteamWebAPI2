using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamWebSession
    {
        private SteamWebRequestParameter steamWebApiKey;

        public SteamWebSession(string steamWebApiKey)
        {
            if (String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("developerKey");
            }

            this.steamWebApiKey = new SteamWebRequestParameter("key", steamWebApiKey);
        }

        public async Task<SteamServerInfo> GetServerInfoAsync()
        {
            SteamWebAPIUtil webInterface = new SteamWebAPIUtil(steamWebApiKey);
            return await webInterface.GetServerInfoAsync();
        }

        public async Task<IReadOnlyCollection<SteamInterface>> GetSupportedAPIListAsync()
        {
            SteamWebAPIUtil webInterface = new SteamWebAPIUtil(steamWebApiKey);
            return await webInterface.GetSupportedAPIListAsync();
        }

        public async Task<PlayerSummary> GetPlayerSummary(string steamId)
        {
            SteamUser steamUser = new SteamUser(steamWebApiKey);
            return await steamUser.GetPlayerSummaryAsync(steamId);
        }
    }
}