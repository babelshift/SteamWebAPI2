using SteamWebAPI2.Models.CSGO;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class CSGOServers : SteamWebInterface
    {
        public CSGOServers(string steamWebApiKey)
            : base(steamWebApiKey, "ICSGOServers_730")
        { }

        public async Task<ServerStatusResult> GetGameServerStatusAsync()
        {
            var gameServerStatus = await CallMethodAsync<ServerStatusResultContainer>("GetGameServersStatus", 1);
            return gameServerStatus.Result;
        }
    }
}