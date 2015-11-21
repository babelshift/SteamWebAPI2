using SteamWebAPI2.Models;
using SteamWebAPI2.Models.CSGO;
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

        public async Task<ServerStatusResult> GetGameServerStatusAsync()
        {
            var gameServerStatus = await GetJsonAsync<ServerStatusResultContainer>(interfaceName, "GetGameServersStatus", 1);
            return gameServerStatus.Result;
        }
    }
}
