using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class LiveLeagueGameFlattenedModel
    {
        public string LeagueName { get; set; }
        public uint SpectatorCount { get; set; }
        public string RadiantTeamName { get; set; }
        public string DireTeamName { get; set; }
        public uint RadiantKillCount { get; set; }
        public uint DireKillCount { get; set; }
        public string ElapsedTimeDisplay { get; set; }
        public uint GameNumber { get; set; }
        public uint BestOf { get; set; }
        public uint RadiantSeriesWins { get; set; }
        public uint DireSeriesWins { get; set; }
        public string LeagueLogoPath { get; set; }
        public string RadiantTeamLogo { get; set; }
        public string DireTeamLogo { get; set; }
        public uint RoshanRespawnTimer { get; set; }
        public ulong LobbyId { get; set; }
        public ulong MatchId { get; set; }
        public double StreamDelay { get; set; }
        public IReadOnlyCollection<LiveLeagueGamePlayerModel> Players { get; set; }
        public double ElapsedTime { get; set; }
        public TowerStateModel RadiantTowerStates { get; set; }
        public TowerStateModel DireTowerStates { get; set; }
        public IReadOnlyCollection<LiveLeagueGameHeroModel> RadiantPicks { get; set; }
        public IReadOnlyCollection<LiveLeagueGameHeroModel> DirePicks { get; set; }
        public IReadOnlyCollection<LiveLeagueGameHeroModel> RadiantBans { get; set; }
        public IReadOnlyCollection<LiveLeagueGameHeroModel> DireBans { get; set; }
        public string LeagueTier { get; set; }
    }
}