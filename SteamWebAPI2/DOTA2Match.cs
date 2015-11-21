using SteamWebAPI2.Models.DOTA2;
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
    }
}