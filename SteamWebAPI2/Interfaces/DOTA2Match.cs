using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using SteamWebAPI2.Utilities;

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

            parameters.AddIfHasValue(leagueId, "league_id");
            parameters.AddIfHasValue(matchId, "match_id");

            var liveLeagueGames = await CallMethodAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1);

            var liveLeagueGamesModel = AutoMapperConfiguration.Mapper.Map<IList<LiveLeagueGame>, IList<LiveLeagueGameModel>>(liveLeagueGames.Result.Games);

            return new ReadOnlyCollection<LiveLeagueGameModel>(liveLeagueGamesModel);
        }

        public async Task<MatchDetailModel> GetMatchDetailsAsync(long matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(matchId, "match_id");

            var matchDetail = await CallMethodAsync<MatchDetailResultContainer>("GetMatchDetails", 1);

            var matchDetailModel = AutoMapperConfiguration.Mapper.Map<MatchDetailResult, MatchDetailModel>(matchDetail.Result);

            return matchDetailModel;
        }

        public async Task<MatchHistoryModel> GetMatchHistoryAsync(int? heroId = null, int? gameMode = null, int? skill = null,
            string minPlayers = "", string accountId = "", string leagueId = "", long? startAtMatchId = null,
            string matchesRequested = "", string tournamentGamesOnly = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(heroId, "hero_id");
            parameters.AddIfHasValue(gameMode, "game_mode");
            parameters.AddIfHasValue(skill, "skill");
            parameters.AddIfHasValue(minPlayers, "min_players");
            parameters.AddIfHasValue(accountId, "account_id");
            parameters.AddIfHasValue(leagueId, "league_id");
            parameters.AddIfHasValue(startAtMatchId, "start_at_match_id");
            parameters.AddIfHasValue(matchesRequested, "matches_requested");
            parameters.AddIfHasValue(tournamentGamesOnly, "tournament_games_only");

            var matchHistory = await CallMethodAsync<MatchHistoryResultContainer>("GetMatchHistory", 1, parameters);

            var matchHistoryModel = AutoMapperConfiguration.Mapper.Map<MatchHistoryResult, MatchHistoryModel>(matchHistory.Result);

            return matchHistoryModel;
        }

        public async Task<IReadOnlyCollection<MatchHistoryMatchModel>> GetMatchHistoryBySequenceNumberAsync(long? startAtMatchSequenceNumber = null, int? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtMatchSequenceNumber, "start_at_match_seq_num");
            parameters.AddIfHasValue(matchesRequested, "matches_requested");

            var matchHistory = await CallMethodAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1, parameters);

            var matchHistoryModel = AutoMapperConfiguration.Mapper.Map<MatchHistoryBySequenceNumberResult, MatchHistoryModel>(matchHistory.Result);
            
            return matchHistoryModel.Matches;
        }

        public async Task<IReadOnlyCollection<TeamInfoModel>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = null, int? teamsRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtTeamId, "start_at_team_id");
            parameters.AddIfHasValue(teamsRequested, "teams_requested");

            var teamInfos = await CallMethodAsync<TeamInfoResultContainer>("GetTeamInfoByTeamID", 1, parameters);

            var teamInfoModels = AutoMapperConfiguration.Mapper.Map<IList<TeamInfo>, IList<TeamInfoModel>>(teamInfos.Result.Teams);

            return new ReadOnlyCollection<TeamInfoModel>(teamInfoModels);
        }
    }
}