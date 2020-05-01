using AutoMapper;
using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Match : IDOTA2Match
    {
        private readonly IMapper mapper;
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public DOTA2Match(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IDOTA2Match_570", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of all live league games and details. Live league games are games registered in a Dota 2 league and are currently being played.
        /// </summary>
        /// <param name="leagueId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<LiveLeagueGameModel>>> GetLiveLeagueGamesAsync(uint? leagueId = null, ulong? matchId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(leagueId, "league_id");
            parameters.AddIfHasValue(matchId, "match_id");

            var steamWebResponse = await steamWebInterface.GetAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<LiveLeagueGameResultContainer>, ISteamWebResponse<IReadOnlyCollection<LiveLeagueGameModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns the match details and meta data for a specific match that has already been completed.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<MatchDetailModel>> GetMatchDetailsAsync(ulong matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(matchId, "match_id");

            var steamWebResponse = await steamWebInterface.GetAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<MatchDetailResultContainer>, ISteamWebResponse<MatchDetailModel>>(steamWebResponse);

            return steamWebResponseModel;
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
        public async Task<ISteamWebResponse<MatchHistoryModel>> GetMatchHistoryAsync(uint? heroId = null, uint? gameMode = null, uint? skill = null,
            uint? minPlayers = null, ulong? accountId = null, uint? leagueId = null, ulong? startAtMatchId = null,
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

            var steamWebResponse = await steamWebInterface.GetAsync<MatchHistoryResultContainer>("GetMatchHistory", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<MatchHistoryResultContainer>, ISteamWebResponse<MatchHistoryModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of match details based on a sequence number. This allows you to jump forward and backward through the match history dataset.
        /// </summary>
        /// <param name="startAtMatchSequenceNumber"></param>
        /// <param name="matchesRequested"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<MatchHistoryMatchModel>>> GetMatchHistoryBySequenceNumberAsync(ulong? startAtMatchSequenceNumber = null, uint? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtMatchSequenceNumber, "start_at_match_seq_num");
            parameters.AddIfHasValue(matchesRequested, "matches_requested");

            var steamWebResponse = await steamWebInterface.GetAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<MatchHistoryBySequenceNumberResultContainer>,
                ISteamWebResponse<IReadOnlyCollection<MatchHistoryMatchModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of team info meta data objects based on parameters that define which teams to look up.
        /// </summary>
        /// <param name="startAtTeamId"></param>
        /// <param name="teamsRequested"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = null, uint? teamsRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtTeamId, "start_at_team_id");
            parameters.AddIfHasValue(teamsRequested, "teams_requested");

            var steamWebResponse = await steamWebInterface.GetAsync<TeamInfoResultContainer>("GetTeamInfoByTeamID", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<TeamInfoResultContainer>, ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}