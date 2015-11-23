using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchHistoryBySequenceNumberResult
    {
        public int Status { get; set; }
        public List<MatchHistoryMatch> Matches { get; set; }
    }
}