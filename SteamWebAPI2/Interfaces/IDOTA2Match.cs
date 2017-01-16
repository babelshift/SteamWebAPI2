using Steam.Models.DOTA2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Match
    {
        Task<IReadOnlyCollection<LeagueModel>> GetLeagueListingAsync(string language);

        Task<IReadOnlyCollection<LiveLeagueGameModel>> GetLiveLeagueGamesAsync(uint? leagueId = null, ulong? matchId = null);

        Task<MatchDetailModel> GetMatchDetailsAsync(ulong matchId);

        Task<MatchHistoryModel> GetMatchHistoryAsync(uint? heroId = null, uint? gameMode = null, uint? skill = null, uint? minPlayers = null, ulong? accountId = null, uint? leagueId = null, ulong? startAtMatchId = null, string matchesRequested = "", string tournamentGamesOnly = "");

        Task<IReadOnlyCollection<MatchHistoryMatchModel>> GetMatchHistoryBySequenceNumberAsync(ulong? startAtMatchSequenceNumber = null, uint? matchesRequested = null);

        Task<IReadOnlyCollection<TeamInfoModel>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = default(long?), uint? teamsRequested = null);
    }
}