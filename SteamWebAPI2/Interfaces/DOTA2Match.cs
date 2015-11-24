using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Match : SteamWebInterface
    {
        public DOTA2Match(string steamWebApiKey)
            : base(steamWebApiKey, "IDOTA2Match_570")
        {
        }

        public async Task<LeagueResult> GetLeagueListing()
        {
            var leagueListing = await CallMethodAsync<LeagueResultContainer>("GetLeagueListing", 1);
            return leagueListing.Result;
        }

        public async Task<IReadOnlyCollection<LiveLeagueGame>> GetLiveLeagueGames(int? leagueId = null, long? matchId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(leagueId, "league_id", parameters);
            AddToParametersIfHasValue(matchId, "match_id", parameters);

            var liveLeagueGames = await CallMethodAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1, parameters);
            return new ReadOnlyCollection<LiveLeagueGame>(liveLeagueGames.Result.Games);
        }

        public async Task<MatchDetailResult> GetMatchDetails(int matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(matchId, "match_id", parameters);

            var matchDetail = await CallMethodAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);
            return matchDetail.Result;
        }

        public async Task<MatchHistoryResult> GetMatchHistory(int? heroId = null, int? gameMode = null, int? skill = null,
            string minPlayers = "", string accountId = "", string leagueId = "", long? startAtMatchId = null,
            string matchesRequested = "", string tournamentGamesOnly = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(heroId, "hero_id", parameters);
            AddToParametersIfHasValue(gameMode, "game_mode", parameters);
            AddToParametersIfHasValue(skill, "skill", parameters);
            AddToParametersIfHasValue(minPlayers, "min_players", parameters);
            AddToParametersIfHasValue(accountId, "account_id", parameters);
            AddToParametersIfHasValue(leagueId, "league_id", parameters);
            AddToParametersIfHasValue(startAtMatchId, "start_at_match_id", parameters);
            AddToParametersIfHasValue(matchesRequested, "matches_requested", parameters);
            AddToParametersIfHasValue(tournamentGamesOnly, "tournament_games_only", parameters);

            var matchHistory = await CallMethodAsync<MatchHistoryResultContainer>("GetMatchHistory", 1);
            return matchHistory.Result;
        }

        public async Task<MatchHistoryBySequenceNumberResult> GetMatchHistoryBySequenceNumber(long? startAtMatchSequenceNumber = null, int? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(startAtMatchSequenceNumber, "start_at_match_seq_num", parameters);
            AddToParametersIfHasValue(matchesRequested, "matches_requested", parameters);

            var matchHistory = await CallMethodAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1);
            return matchHistory.Result;
        }

        /*
        public async Task<??> GetScheduledLeagueGames(int? dateMin = null, int? dateMax = null)
        {
        }
        */

        public async Task<IReadOnlyCollection<TeamInfo>> GetTeamInfoByTeamId(long? startAtTeamId = null, int? teamsRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(startAtTeamId, "start_at_team_id", parameters);
            AddToParametersIfHasValue(teamsRequested, "teams_requested", parameters);

            var teamInfos = await CallMethodAsync<TeamInfoResultContainer>("GetTeamInfoByTeamID", 1);
            return new ReadOnlyCollection<TeamInfo>(teamInfos.Result.Teams);
        }

        /*
        public async Task<??> GetTopLiveGame(int? partner = null)
        {
        }
        */

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="leagueId">This method only works properly with 65006 league id (The International) for some reason</param>
        /// <param name="heroId"></param>
        /// <param name="matchId"></param>
        /// <param name="phaseId"></param>
        /// <returns></returns>
        public void GetTournamentPlayerStats(string accountId = "", string leagueId = "", string heroId = "",
            long? matchId = null, int? phaseId = null)
        {
            throw new NotImplementedException("I can't find good test conditions for this, so I don't know how to implement a response parser.");
        }
    }
}