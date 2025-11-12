using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Ticket : IDOTA2Ticket
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public DOTA2Ticket(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IDOTA2Ticket_570", steamWebRequest)
                : steamWebInterface;
        }
    }
}