using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamUser : SteamWebInterface
    {
        public SteamUser(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUser") { }

        public async Task<PlayerSummary> GetPlayerSummaryAsync(string steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("steamids", steamId));
            var playerSummary = await CallMethodAsync<PlayerSummaryResponseContainer>("GetPlayerSummaries", 2, parameters);

            if (playerSummary.Response.Players.Count > 0)
            {
                return playerSummary.Response.Players[0];
            }
            else
            {
                return null;
            }
        }
    }
}