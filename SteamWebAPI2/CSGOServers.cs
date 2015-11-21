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
        public CSGOServers(SteamWebRequestParameter developerKey)
            : base(developerKey, "ICSGOServers_730") { }

        public async Task<CSGOServerStatusResult> GetGameServerStatusAsync()
        {
            var gameServerStatus = await GetJsonAsync<CSGOServerStatusResultContainer>(interfaceName, "GetGameServersStatus", 1);
            return gameServerStatus.Result;
        }
    }
}
