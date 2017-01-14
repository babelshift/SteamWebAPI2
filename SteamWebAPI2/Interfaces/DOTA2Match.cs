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

        /// <summary>
        /// Returns a collection of all leagues registered in Dota 2.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<LeagueModel>> GetLeagueListingAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            
            parameters.AddIfHasValue(language, "language");

            var leagueListing = await GetAsync<LeagueResultContainer>("GetLeagueListing", 1, parameters);

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

        /// <summary>
        /// Returns a collection of all live league games and details. Live league games are games registered in a Dota 2 league and are currently being played.
        /// </summary>
        /// <param name="leagueId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<LiveLeagueGameModel>> GetLiveLeagueGamesAsync(int? leagueId = null, long? matchId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(leagueId, "league_id");
            parameters.AddIfHasValue(matchId, "match_id");

            var liveLeagueGames = await GetAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1);

            var liveLeagueGamesModel = AutoMapperConfiguration.Mapper.Map<IList<LiveLeagueGame>, IList<LiveLeagueGameModel>>(liveLeagueGames.Result.Games);

            return new ReadOnlyCollection<LiveLeagueGameModel>(liveLeagueGamesModel);
        }

        /// <summary>
        /// Returns the match details and meta data for a specific match that has already been completed.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<MatchDetailModel> GetMatchDetailsAsync(long matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(matchId, "match_id");

            var matchDetail = await GetAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);

            var matchDetailModel = AutoMapperConfiguration.Mapper.Map<MatchDetailResult, MatchDetailModel>(matchDetail.Result);

            return matchDetailModel;
        }

        /// <summary>
        /// Returns a collection of match details in history based on specific parameters.
        /// </summary>
        /// <param name="heroId"></param>
        /// <param name="gameMode"></param>
        /// <param name="skill"></param>
        /// <param name="minPlayers"></param>
        /// <param name="accountId"></param>
        /// <param name="leagueId"></param>
        /// <param name="startAtMatchId"></param>
        /// <param name="matchesRequested"></param>
        /// <param name="tournamentGamesOnly"></param>
        /// <returns></returns>
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

            var matchHistory = await GetAsync<MatchHistoryResultContainer>("GetMatchHistory", 1, parameters);

            var matchHistoryModel = AutoMapperConfiguration.Mapper.Map<MatchHistoryResult, MatchHistoryModel>(matchHistory.Result);

            return matchHistoryModel;
        }

        /// <summary>
        /// Returns a collection of match details based on a sequence number. This allows you to jump forward and backward through the match history dataset.
        /// </summary>
        /// <param name="startAtMatchSequenceNumber"></param>
        /// <param name="matchesRequested"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<MatchHistoryMatchModel>> GetMatchHistoryBySequenceNumberAsync(long? startAtMatchSequenceNumber = null, int? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtMatchSequenceNumber, "start_at_match_seq_num");
            parameters.AddIfHasValue(matchesRequested, "matches_requested");

            var matchHistory = await GetAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1, parameters);

            var matchHistoryModel = AutoMapperConfiguration.Mapper.Map<MatchHistoryBySequenceNumberResult, MatchHistoryModel>(matchHistory.Result);
            
            return matchHistoryModel.Matches;
        }

        /// <summary>
        /// Returns a collection of team info meta data objects based on parameters that define which teams to look up.
        /// </summary>
        /// <param name="startAtTeamId"></param>
        /// <param name="teamsRequested"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<TeamInfoModel>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = null, int? teamsRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtTeamId, "start_at_team_id");
            parameters.AddIfHasValue(teamsRequested, "teams_requested");

            var teamInfos = await GetAsync<TeamInfoResultContainer>("GetTeamInfoByTeamID", 1, parameters);

            var teamInfoModels = AutoMapperConfiguration.Mapper.Map<IList<TeamInfo>, IList<TeamInfoModel>>(teamInfos.Result.Teams);

            return new ReadOnlyCollection<TeamInfoModel>(teamInfoModels);
        }
    }
}