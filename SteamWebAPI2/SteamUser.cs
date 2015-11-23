using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamUser : SteamWebInterface
    {
        public SteamUser(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUser") { }

        public async Task<PlayerSummary> GetPlayerSummaryAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamids", steamId, parameters);
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

        public async Task<IReadOnlyCollection<Friend>> GetFriendsListAsync(long steamId, string relationship = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            AddToParametersIfHasValue("relationship", relationship, parameters);
            var friendsListResult = await CallMethodAsync<FriendsListResultContainer>("GetFriendList", 1, parameters);
            return new ReadOnlyCollection<Friend>(friendsListResult.Result.Friends);
        }
    }
}