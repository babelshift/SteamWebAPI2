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
    }
}