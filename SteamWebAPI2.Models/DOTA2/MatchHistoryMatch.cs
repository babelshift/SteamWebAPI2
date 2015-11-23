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
}