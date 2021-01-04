using SteamWebAPI2.Utilities;
using System.Threading.Tasks;
using Steam.Models.SteamUserAuth;

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
        Task<ISteamWebResponse<SteamUserAuthResponseModel>> AuthenticateUserTicket(uint appId, string ticket);
    }
}