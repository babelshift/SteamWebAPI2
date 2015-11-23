using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchDetailResult
    {
        public IList<MatchPlayer> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_win")]
        public bool RadiantWin { get; set; }

        public int Duration { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public int StartTime { get; set; }

        [JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public int MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "tower_status_radiant")]
        public int TowerStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "tower_status_dire")]
        public int TowerStatusDire { get; set; }

        [JsonProperty(PropertyName = "barracks_status_radiant")]
        public int BarracksStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "barracks_status_dire")]
        public int BarracksStatusDire { get; set; }

        public int Cluster { get; set; }

        [JsonProperty(PropertyName = "first_blood_time")]
        public int FirstBloodTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public int LobbyType { get; set; }

        [JsonProperty(PropertyName = "human_players")]
        public int HumanPlayers { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "positive_votes")]
        public int PositiveVotes { get; set; }

        [JsonProperty(PropertyName = "negative_votes")]
        public int NegativeVotes { get; set; }

        [JsonProperty(PropertyName = "game_mode")]
        public int GameMode { get; set; }

        public int Engine { get; set; }

        [JsonProperty(PropertyName = "radiant_team_id")]
        public int RadiantTeamId { get; set; }

        [JsonProperty(PropertyName = "radiant_name")]
        public string RadiantName { get; set; }

        [JsonProperty(PropertyName = "radiant_logo")]
        public long RadiantLogo { get; set; }

        [JsonProperty(PropertyName = "radiant_team_complete")]
        public int RadiantTeamComplete { get; set; }

        [JsonProperty(PropertyName = "dire_team_id")]
        public int DireTeamId { get; set; }

        [JsonProperty(PropertyName = "dire_name")]
        public string DireName { get; set; }

        [JsonProperty(PropertyName = "dire_logo")]
        public long DireLogo { get; set; }

        [JsonProperty(PropertyName = "dire_team_complete")]
        public int DireTeamComplete { get; set; }

        [JsonProperty(PropertyName = "radiant_captain")]
        public int RadiantCaptain { get; set; }

        [JsonProperty(PropertyName = "dire_captain")]
        public int DireCaptain { get; set; }

        [JsonProperty(PropertyName = "picks_bans")]
        public IList<MatchPickBan> PicksAndBans { get; set; }
    }
}