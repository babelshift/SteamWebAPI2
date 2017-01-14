using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUserAuth : SteamWebInterface, ISteamUserAuth
    {
        public SteamUserAuth(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUserAuth")
        {
        }

        /// <summary>
        /// Authenticates a Steam User based on a User Ticket from GetAuthSessionTicket
        /// </summary>
        /// <param name="appId">App ID of the game to authenticate against</param>
        /// <param name="ticket">Ticket from GetAuthSessionTicket</param>
        /// <returns>Results of authentication request</returns>
        public async Task<dynamic> AuthenticateUserTicket(int appId, string ticket)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(ticket, "ticket");
            var playingSharedGameResult = await GetAsync<dynamic>("AuthenticateUserTicket", 1, parameters);
            return playingSharedGameResult;
        }
    }
}