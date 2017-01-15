using Steam.Models.CSGO;
using SteamWebAPI2.Models.CSGO;
using System.Threading.Tasks;
using System.Linq;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    /// <summary>
    /// Represents a Steam Web API interface endpoint located at ICSGOServers_730
    /// </summary>
    public class CSGOServers : ICSGOServers
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public CSGOServers(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null 
                ? new SteamWebInterface(steamWebApiKey, "ICSGOServers_730") 
                : steamWebInterface;
        }

        /// <summary>
        /// Maps to the Steam Web API interface/method of ICSGOServers_730/GetGameServersStatus/v1
        /// </summary>
        /// <returns></returns>
        public async Task<ServerStatusModel> GetGameServerStatusAsync()
        {
            var gameServerStatus = await steamWebInterface.GetAsync<ServerStatusResultContainer>("GetGameServersStatus", 1);

            var gameServerStatusModel = AutoMapperConfiguration.Mapper.Map<ServerStatusResult, ServerStatusModel>(gameServerStatus.Result);

            return gameServerStatusModel;
        }
    }
}