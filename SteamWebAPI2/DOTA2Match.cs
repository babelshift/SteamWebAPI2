using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2
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

            AddToParametersIfHasValue("league_id", leagueId, parameters);
            AddToParametersIfHasValue("match_id", matchId, parameters);

            var liveLeagueGames = await CallMethodAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1, parameters);
            return new ReadOnlyCollection<LiveLeagueGame>(liveLeagueGames.Result.Games);
        }

        public async Task<MatchDetailResult> GetMatchDetails(int matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("match_id", matchId, parameters);

            var matchDetail = await CallMethodAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);
            return matchDetail.Result;
        }

        public async Task<MatchHistoryResult> GetMatchHistory(int? heroId = null, int? gameMode = null, int? skill = null, 
            string minPlayers = "", string accountId = "", string leagueId = "", long? startAtMatchId = null, 
            string matchesRequested = "", string tournamentGamesOnly = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("hero_id", heroId, parameters);
            AddToParametersIfHasValue("game_mode", gameMode, parameters);
            AddToParametersIfHasValue("skill", skill, parameters);
            AddToParametersIfHasValue("min_players", minPlayers, parameters);
            AddToParametersIfHasValue("account_id", accountId, parameters);
            AddToParametersIfHasValue("league_id", leagueId, parameters);
            AddToParametersIfHasValue("start_at_match_id", startAtMatchId, parameters);
            AddToParametersIfHasValue("matches_requested", matchesRequested, parameters);
            AddToParametersIfHasValue("tournament_games_only", tournamentGamesOnly, parameters);

            var matchHistory = await CallMethodAsync<MatchHistoryResultContainer>("GetMatchHistory", 1);
            return matchHistory.Result;
        }

        public async Task<MatchHistoryBySequenceNumberResult> GetMatchHistoryBySequenceNumber(long? startAtMatchSequenceNumber = null, int? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("start_at_match_seq_num", startAtMatchSequenceNumber, parameters);
            AddToParametersIfHasValue("matches_requested", matchesRequested, parameters);

            var matchHistory = await CallMethodAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1);
            return matchHistory.Result;
        }
    }
}