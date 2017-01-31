using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class MatchHistoryBySequenceNumberResult
    {
        public uint Status { get; set; }
        public IList<MatchHistoryMatch> Matches { get; set; }
    }

    internal class MatchHistoryBySequenceNumberResultContainer
    {
        public MatchHistoryBySequenceNumberResult Result { get; set; }
    }
}