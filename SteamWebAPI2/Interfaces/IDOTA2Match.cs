using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.DOTA2;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Match
    {
        Task<LeagueResult> GetLeagueListingAsync();
        Task<IReadOnlyCollection<LiveLeagueGame>> GetLiveLeagueGamesAsync(int? leagueId = default(int?), long? matchId = default(long?));
        Task<MatchDetailResult> GetMatchDetailsAsync(int matchId);
        Task<MatchHistoryResult> GetMatchHistoryAsync(int? heroId = default(int?), int? gameMode = default(int?), int? skill = default(int?), string minPlayers = "", string accountId = "", string leagueId = "", long? startAtMatchId = default(long?), string matchesRequested = "", string tournamentGamesOnly = "");
        Task<MatchHistoryBySequenceNumberResult> GetMatchHistoryBySequenceNumberAsync(long? startAtMatchSequenceNumber = default(long?), int? matchesRequested = default(int?));
        Task<IReadOnlyCollection<TeamInfo>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = default(long?), int? teamsRequested = default(int?));
        void GetTournamentPlayerStats(string accountId = "", string leagueId = "", string heroId = "", long? matchId = default(long?), int? phaseId = default(int?));
    }
}