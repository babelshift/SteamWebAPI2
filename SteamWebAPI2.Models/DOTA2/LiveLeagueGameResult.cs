using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGameResult
    {
        public IList<LiveLeagueGame> Games { get; set; }
        public int Status { get; set; }
    }
}