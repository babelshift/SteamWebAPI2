using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUser : SteamWebInterface
    {
        public SteamUser(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUser")
        { }

        public async Task<PlayerSummary> GetPlayerSummaryAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamids", steamId, parameters);
            var playerSummary = await CallMethodAsync<PlayerSummaryResultContainer>("GetPlayerSummaries", 2, parameters);

            if (playerSummary.Result.Players.Count > 0)
            {
                return playerSummary.Result.Players[0];
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

        public async Task<IReadOnlyCollection<PlayerBans>> GetPlayerBansAsync(long steamId)
        {
            return await GetPlayerBansAsync(new List<long>() { steamId });
        }

        public async Task<IReadOnlyCollection<PlayerBans>> GetPlayerBansAsync(IReadOnlyCollection<long> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            string steamIdsParamValue = String.Join(",", steamIds);

            AddToParametersIfHasValue("steamids", steamIdsParamValue, parameters);

            var playerBansContainer = await CallMethodAsync<PlayerBansContainer>("GetPlayerBans", 1, parameters);
            return new ReadOnlyCollection<PlayerBans>(playerBansContainer.PlayerBans);
        }

        public async Task<UserGroupListResult> GetUserGroupsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("steamid", steamId, parameters);

            var userGroupResultContainer = await CallMethodAsync<UserGroupListResultContainer>("GetUserGroupList", 1, parameters);
            return userGroupResultContainer.Result;
        }

        public async Task<long> ResolveVanityUrlAsync(string vanityUrl, int? urlType = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("vanityurl", vanityUrl, parameters);
            AddToParametersIfHasValue("url_type", urlType, parameters);

            var userGroupResultContainer = await CallMethodAsync<ResolveVanityUrlResultContainer>("ResolveVanityURL", 1, parameters);
            return userGroupResultContainer.Result.SteamId;
        }
    }
}