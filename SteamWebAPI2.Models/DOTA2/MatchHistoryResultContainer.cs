using Newtonsoft.Json;
using SteamWebAPI2.Models.Utilities;
using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchHistoryMatch
    {
        [JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public int MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public int LobbyType { get; set; }

        [JsonProperty(PropertyName = "radiant_team_id")]
        public int RadiantTeamId { get; set; }

        [JsonProperty(PropertyName = "dire_team_id")]
        public int DireTeamId { get; set; }

        public List<MatchHistoryPlayer> Players { get; set; }
    }

    public class MatchHistoryPlayer
    {
        [JsonProperty(PropertyName = "account_id")]
        public object AccountId { get; set; }

        [JsonProperty(PropertyName = "player_slot")]
        public int PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
    }

    public class MatchHistoryResult
    {
        public int Status { get; set; }

        [JsonProperty(PropertyName = "num_results")]
        public int NumResults { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "results_remaining")]
        public int ResultsRemaining { get; set; }

        public IList<MatchHistoryMatch> Matches { get; set; }
    }

    public class MatchHistoryResultContainer
    {
        public MatchHistoryResult Result { get; set; }
    }
}