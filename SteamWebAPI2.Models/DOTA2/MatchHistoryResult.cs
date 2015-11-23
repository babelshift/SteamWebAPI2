using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchHistoryResult
    {
        public int Status { get; set; }

        [JsonProperty(PropertyName = "num_results")]
        public int NumResults { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "results_remaining")]
        public int ResultsRemaining { get; set; }

        public List<MatchHistoryMatch> Matches { get; set; }
    }
}