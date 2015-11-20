using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    internal class SteamUser : SteamWebRequest
    {
        public SteamUser(SteamWebRequestParameter developerKey) : base(developerKey) { }

        public async Task<PlayerSummary> GetPlayerSummaryAsync(string steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("steamids", steamId));
            var playerSummary = await GetJsonAsync<PlayerSummaryResponseContainer>("ISteamUser", "GetPlayerSummaries", 2, parameters);

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