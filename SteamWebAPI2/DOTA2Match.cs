using SteamWebAPI2.Models.DOTA2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    internal class DOTA2Match : SteamWebRequest
    {
        public DOTA2Match(SteamWebRequestParameter developerKey)
            : base(developerKey, "IDOTA2Match_570")
        { }

        public async Task<LeagueResult> GetLeagueListing()
        {
            var leagueListing = await GetJsonAsync<LeagueResultContainer>(interfaceName, "GetLeagueListing", 1);
            return leagueListing.Result;
        }

        public async Task<IReadOnlyCollection<LiveLeagueGame>> GetLiveLeagueGames()
        {
            var liveLeagueGames = await GetJsonAsync<LiveLeagueGameResultContainer>(interfaceName, "GetLiveLeagueGames", 1);
            return new ReadOnlyCollection<LiveLeagueGame>(liveLeagueGames.Result.Games);
        }

        public async Task<MatchDetailResult> GetMatchDetails(int matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("match_id", matchId.ToString()));
            var matchDetail = await GetJsonAsync<MatchDetailResultContainer>(interfaceName, "GetMatchDetails", 1, parameters);
            return matchDetail.Result;
        }

        public async Task<MatchHistoryResult> GetMatchHistory()
        {
            var matchHistory = await GetJsonAsync<MatchHistoryResultContainer>(interfaceName, "GetMatchHistory", 1);
            return matchHistory.Result;
        }
    }
}