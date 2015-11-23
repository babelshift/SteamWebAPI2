using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class DOTA2Ticket : SteamWebInterface
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
        public async Task GetSteamAccountValidForEventAsync(int eventId, long steamId)
        {
            throw new NotImplementedException("I can't find good test conditions for this, so I don't know how to implement a response parser.");
        }
    }
}
