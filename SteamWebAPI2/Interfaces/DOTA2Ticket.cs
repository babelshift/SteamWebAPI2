using System;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Ticket : SteamWebInterface, IDOTA2Ticket
    {
        public DOTA2Ticket(string steamWebApiKey)
            : base(steamWebApiKey, "IDOTA2Ticket_570")
        {
        }
    }
}