using System;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Ticket : SteamWebInterface, IDOTA2Ticket
    {
        public DOTA2Ticket(string steamWebApiKey)
            : base(steamWebApiKey, "IDOTA2Ticket_570")
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventId">This is possibly the same as League Id according to documentation...why?</param>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public void GetSteamAccountValidForEvent(int eventId, long steamId)
        {
            throw new NotImplementedException("I can't find good test conditions for this, so I don't know how to implement a response parser.");
        }
    }
}