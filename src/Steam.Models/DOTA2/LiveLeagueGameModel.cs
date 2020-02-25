using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class LiveLeagueGameModel
    {
        public IReadOnlyCollection<LiveLeagueGamePlayerInfoModel> Players { get; set; }

        public LiveLeagueGameTeamRadiantInfoModel RadiantTeam { get; set; }

        public LiveLeagueGameTeamDireInfoModel DireTeam { get; set; }

        public ulong LobbyId { get; set; }

        public ulong MatchId { get; set; }

        public uint Spectators { get; set; }

        public uint SeriesId { get; set; }

        public uint GameNumber { get; set; }

        public uint LeagueId { get; set; }

        public double StreamDelaySeconds { get; set; }

        public uint RadiantSeriesWins { get; set; }

        public uint DireSeriesWins { get; set; }

        public uint SeriesType { get; set; }

        public uint LeagueSeriesId { get; set; }

        public uint LeagueGameId { get; set; }

        public string StageName { get; set; }

        public DotaLeagueTier LeagueTier { get; set; }

        public LiveLeagueGameScoreboardModel Scoreboard { get; set; }
    }
}