using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchHistoryBySequenceNumberResult
    {
        public int Status { get; set; }
        public IList<MatchHistoryMatch> Matches { get; set; }
    }

    public class MatchHistoryBySequenceNumberResultContainer
    {
        public MatchHistoryBySequenceNumberResult Result { get; set; }
    }
}