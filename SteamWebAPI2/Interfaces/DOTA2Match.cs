using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Match : SteamWebInterface, IDOTA2Match
    {
        public DOTA2Match(string steamWebApiKey)
            : base(steamWebApiKey, "IDOTA2Match_570")
        {
        }

        public async Task<IReadOnlyCollection<LeagueModel>> GetLeagueListingAsync()
        {
            var leagueListing = await CallMethodAsync<LeagueResultContainer>("GetLeagueListing", 1);

            var leagueModels = leagueListing.Result.Leagues.Select(x => new LeagueModel()
            {
                Description = x.Description,
                ItemDef = x.ItemDef,
                LeagueId = x.LeagueId,
                Name = x.Name,
                TournamentUrl = x.TournamentUrl
            }).ToList().AsReadOnly();

            return leagueModels;
        }

        public async Task<IReadOnlyCollection<LiveLeagueGameModel>> GetLiveLeagueGamesAsync(int? leagueId = null, long? matchId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(leagueId, "league_id", parameters);
            AddToParametersIfHasValue(matchId, "match_id", parameters);

            var liveLeagueGames = await CallMethodAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1, parameters);

            var liveLeagueGamesModel = AutoMapperConfiguration.Mapper.Map<IList<LiveLeagueGame>, IList<LiveLeagueGameModel>>(liveLeagueGames.Result.Games);

            return new ReadOnlyCollection<LiveLeagueGameModel>(liveLeagueGamesModel);
        }

        public async Task<MatchDetailModel> GetMatchDetailsAsync(long matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(matchId, "match_id", parameters);

            var matchDetail = await CallMethodAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);

            var matchDetailModel = AutoMapperConfiguration.Mapper.Map<MatchDetailResult, MatchDetailModel>(matchDetail.Result);

            return matchDetailModel;
        }

        public async Task<MatchHistoryModel> GetMatchHistoryAsync(int? heroId = null, int? gameMode = null, int? skill = null,
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

            var matchHistory = await CallMethodAsync<MatchHistoryResultContainer>("GetMatchHistory", 1, parameters);

            var matchHistoryModel = AutoMapperConfiguration.Mapper.Map<MatchHistoryResult, MatchHistoryModel>(matchHistory.Result);

            return matchHistoryModel;
        }

        public async Task<IReadOnlyCollection<MatchHistoryMatchModel>> GetMatchHistoryBySequenceNumberAsync(long? startAtMatchSequenceNumber = null, int? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(startAtMatchSequenceNumber, "start_at_match_seq_num", parameters);
            AddToParametersIfHasValue(matchesRequested, "matches_requested", parameters);

            var matchHistory = await CallMethodAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1, parameters);

            var matchHistoryModel = AutoMapperConfiguration.Mapper.Map<MatchHistoryBySequenceNumberResult, MatchHistoryModel>(matchHistory.Result);
            
            return matchHistoryModel.Matches;
        }

        public async Task<IReadOnlyCollection<TeamInfoModel>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = null, int? teamsRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(startAtTeamId, "start_at_team_id", parameters);
            AddToParametersIfHasValue(teamsRequested, "teams_requested", parameters);

            var teamInfos = await CallMethodAsync<TeamInfoResultContainer>("GetTeamInfoByTeamID", 1, parameters);

            var teamInfoModels = AutoMapperConfiguration.Mapper.Map<IList<TeamInfo>, IList<TeamInfoModel>>(teamInfos.Result.Teams);

            return new ReadOnlyCollection<TeamInfoModel>(teamInfoModels);
        }
    }
}