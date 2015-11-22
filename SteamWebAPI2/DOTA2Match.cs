using SteamWebAPI2.Models.DOTA2;
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

            if(leagueId.HasValue)
            {
                parameters.Add(new SteamWebRequestParameter("league_id", leagueId.Value.ToString()));
            }

            if (matchId.HasValue)
            {
                parameters.Add(new SteamWebRequestParameter("match_id", matchId.Value.ToString()));
            }

            var liveLeagueGames = await CallMethodAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1, parameters);
            return new ReadOnlyCollection<LiveLeagueGame>(liveLeagueGames.Result.Games);
        }

        public async Task<MatchDetailResult> GetMatchDetails(int matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("match_id", matchId.ToString()));
            var matchDetail = await CallMethodAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);
            return matchDetail.Result;
        }

        public async Task<MatchHistoryResult> GetMatchHistory()
        {
            var matchHistory = await CallMethodAsync<MatchHistoryResultContainer>("GetMatchHistory", 1);
            return matchHistory.Result;
        }
    }
}