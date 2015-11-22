using SteamWebAPI2.Models;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Models.DOTA2;
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

        public async Task<ServerStatusResult> GetCSGOGameServerStatusAsync()
        {
            CSGOServers csgoServers = new CSGOServers(steamWebApiKey);
            return await csgoServers.GetGameServerStatusAsync();
        }
        
        public async Task<PlayerOfficialInfoResult> GetDOTA2PlayerOfficialInfo(long steamId)
        {
            DOTA2Fantasy dota2Fantasy = new DOTA2Fantasy(steamWebApiKey);
            return await dota2Fantasy.GetPlayerOfficialInfo(steamId);
        }

        public async Task<ProPlayerListResult> GetDOTA2ProPlayerList()
        {
            DOTA2Fantasy dota2Fantasy = new DOTA2Fantasy(steamWebApiKey);
            return await dota2Fantasy.GetProPlayerList();
        }

        public async Task<LeagueResult> GetDOTA2LeagueListing()
        {
            DOTA2Match dota2Match = new DOTA2Match(steamWebApiKey);
            return await dota2Match.GetLeagueListing();
        }

        public async Task<IReadOnlyCollection<LiveLeagueGame>> GetDOTA2LiveLeagueGames()
        {
            DOTA2Match dota2Match = new DOTA2Match(steamWebApiKey);
            return await dota2Match.GetLiveLeagueGames();
        }
    }
}