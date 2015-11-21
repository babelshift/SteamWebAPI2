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

        public async Task<PlayerSummary> GetPlayerSummaryAsync(string steamId)
        {
            SteamUser steamUser = new SteamUser(steamWebApiKey);
            return await steamUser.GetPlayerSummaryAsync(steamId);
        }

        public async Task<CSGOServerStatusResult> GetCSGOGameServerStatusAsync()
        {
            CSGOServers csgoServers = new CSGOServers(steamWebApiKey);
            return await csgoServers.GetGameServerStatusAsync();
        }
        
        public async Task<DOTA2PlayerOfficialInfoResult> GetDOTA2PlayerOfficialInfo(long steamId)
        {
            DOTA2Fantasy dotaFantasy = new DOTA2Fantasy(steamWebApiKey);
            return await dotaFantasy.GetPlayerOfficialInfo(steamId);
        }
    }
}