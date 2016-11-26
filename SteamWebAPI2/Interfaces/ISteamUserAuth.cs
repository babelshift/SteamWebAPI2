using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUserAuth
    {
        /// <summary>
        /// Authenticates a Steam User based on a User Ticket from GetAuthSessionTicket
        /// </summary>
        /// <param name="appId">App ID of the game to authenticate against</param>
        /// <param name="ticket">Ticket from GetAuthSessionTicket</param>
        /// <returns>Results of authentication request</returns>
        Task<dynamic> AuthenticateUserTicket(int appId, string ticket);
    }
}
