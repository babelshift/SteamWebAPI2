using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGame
    {
        public IList<LiveLeagueGamePlayerInfo> Players { get; set; }
        [JsonProperty(PropertyName = "radiant_team")]
        public LiveLeagueGameTeamRadiantInfo RadiantTeam { get; set; }
        [JsonProperty(PropertyName = "dire_team")]
        public LiveLeagueGameTeamDireInfo DireTeam { get; set; }
        [JsonProperty(PropertyName = "lobby_id")]
        public long LobbyId { get; set; }
        [JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }
        public int Spectators { get; set; }
        [JsonProperty(PropertyName = "series_id")]
        public int SeriesId { get; set; }
        [JsonProperty(PropertyName = "game_number")]
        public int GameNumber { get; set; }
        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }
        [JsonProperty(PropertyName = "stream_delay_s")]
        public double StreamDelaySeconds { get; set; }
        [JsonProperty(PropertyName = "radiant_series_wins")]
        public int RadiantSeriesWins { get; set; }
        [JsonProperty(PropertyName = "dire_series_wins")]
        public int DireSeriesWins { get; set; }
        [JsonProperty(PropertyName = "series_type")]
        public int SeriesType { get; set; }
        [JsonProperty(PropertyName = "league_series_id")]
        public int LeagueSeriesId { get; set; }
        [JsonProperty(PropertyName = "league_game_id")]
        public int LeagueGameId { get; set; }
        [JsonProperty(PropertyName = "stage_name")]
        public string StageName { get; set; }
        [JsonProperty(PropertyName = "league_tier")]
        public int LeagueTier { get; set; }
        public LiveLeagueGameScoreboard Scoreboard { get; set; }
    }
}
