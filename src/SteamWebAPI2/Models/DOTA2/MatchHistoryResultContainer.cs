using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class MatchHistoryMatch
    {
        [JsonProperty(PropertyName = "match_id")]
        public ulong MatchId { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public uint MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public uint LobbyType { get; set; }

        [JsonProperty(PropertyName = "radiant_team_id")]
        public uint RadiantTeamId { get; set; }

        [JsonProperty(PropertyName = "dire_team_id")]
        public uint DireTeamId { get; set; }

        public List<MatchHistoryPlayer> Players { get; set; }
    }

    internal class MatchHistoryPlayer
    {
        [JsonProperty(PropertyName = "account_id")]
        public uint AccountId { get; set; }

        [JsonProperty(PropertyName = "player_slot")]
        public uint PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }
    }

    internal class MatchHistoryResult
    {
        public uint Status { get; set; }

        [JsonProperty(PropertyName = "num_results")]
        public uint NumResults { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public uint TotalResults { get; set; }

        [JsonProperty(PropertyName = "results_remaining")]
        public uint ResultsRemaining { get; set; }

        public IList<MatchHistoryMatch> Matches { get; set; }
    }

    internal class MatchHistoryResultContainer
    {
        public MatchHistoryResult Result { get; set; }
    }
}