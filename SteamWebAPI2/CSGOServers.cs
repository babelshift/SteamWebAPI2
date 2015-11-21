using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    internal class CSGOServers : SteamWebRequest
    {
        public CSGOServers(SteamWebRequestParameter developerKey) : base(developerKey) { }

        public async Task<CSGOServerStatusResult> GetGameServerStatusAsync()
        {
            var gameServerStatus = await GetJsonAsync<CSGOServerStatusResultContainer>("ICSGOServers_730", "GetGameServersStatus", 1);
            return gameServerStatus.Result;
        }
    }
}
