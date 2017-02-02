using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUserAuth : ISteamUserAuth
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamUserAuth(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ISteamUserAuth")
                : steamWebInterface;
        }

        /// <summary>
        /// Authenticates a Steam User based on a User Ticket from GetAuthSessionTicket
        /// </summary>
        /// <param name="appId">App ID of the game to authenticate against</param>
        /// <param name="ticket">Ticket from GetAuthSessionTicket</param>
        /// <returns>Results of authentication request</returns>
        public async Task<ISteamWebResponse<dynamic>> AuthenticateUserTicket(uint appId, string ticket)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(ticket, "ticket");
            var playingSharedGameResult = await steamWebInterface.GetAsync<dynamic>("AuthenticateUserTicket", 1, parameters);
            return playingSharedGameResult;
        }
    }
}