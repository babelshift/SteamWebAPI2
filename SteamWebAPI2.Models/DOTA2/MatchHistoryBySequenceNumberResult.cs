using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchHistoryBySequenceNumberResult
    {
        public int Status { get; set; }
        public List<MatchHistoryMatch> Matches { get; set; }
    }
}
