using SteamWebAPI2.Models;
using SteamWebAPI2.Models.CSGO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class CSGOServers : SteamWebInterface
    {
        public CSGOServers(string steamWebApiKey)
            : base(steamWebApiKey, "ICSGOServers_730") { }

        public async Task<ServerStatusResult> GetGameServerStatusAsync()
        {
            var gameServerStatus = await CallMethodAsync<ServerStatusResultContainer>("GetGameServersStatus", 1);
            return gameServerStatus.Result;
        }
    }
}
