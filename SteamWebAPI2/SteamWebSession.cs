using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamWebSession
    {
        private SteamWebRequestParameter developerKey;

        public SteamWebSession(string developerKey)
        {
            this.developerKey = new SteamWebRequestParameter("key", developerKey);
        }

        public async Task<SteamServerInfo> GetServerInfoAsync()
        {
            SteamWebAPIUtil webInterface = new SteamWebAPIUtil(developerKey);
            return await webInterface.GetServerInfoAsync();
        }

        public async Task<IReadOnlyCollection<SteamInterface>> GetSupportedAPIListAsync()
        {
            SteamWebAPIUtil webInterface = new SteamWebAPIUtil(developerKey);
            return await webInterface.GetSupportedAPIListAsync();
        }

        public async Task<PlayerSummary> GetPlayerSummary(string steamId)
        {
            SteamUser steamUser = new SteamUser(developerKey);
            return await steamUser.GetPlayerSummaryAsync(steamId);
        }
    }
}
