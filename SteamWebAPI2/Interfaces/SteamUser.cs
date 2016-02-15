using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using SteamWebAPI2.Exceptions;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUser : SteamWebInterface, ISteamUser
    {
        public SteamUser(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUser")
        { }

        public async Task<PlayerSummaryModel> GetPlayerSummaryAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue(steamId, "steamids", parameters);
            var playerSummary = await CallMethodAsync<PlayerSummaryResultContainer>("GetPlayerSummaries", 2, parameters);

            if (playerSummary.Result.Players != null && playerSummary.Result.Players.Count > 0)
            {
                var playerSummaryModel = AutoMapperConfiguration.Mapper.Map<PlayerSummary, PlayerSummaryModel>(playerSummary.Result.Players[0]);
                return playerSummaryModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<IReadOnlyCollection<FriendModel>> GetFriendsListAsync(long steamId, string relationship = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue(steamId, "steamid", parameters);
            AddToParametersIfHasValue(relationship, "relationship", parameters);
            var friendsListResult = await CallMethodAsync<FriendsListResultContainer>("GetFriendList", 1, parameters);

            var friendsListModel = AutoMapperConfiguration.Mapper.Map<IList<Friend>, IList<FriendModel>>(friendsListResult.Result.Friends);

            return new ReadOnlyCollection<FriendModel>(friendsListModel);
        }

        public async Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(long steamId)
        {
            var result = await GetPlayerBansAsync(new List<long>() { steamId });
            return result;
        }

        public async Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(IReadOnlyCollection<long> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            string steamIdsParamValue = String.Join(",", steamIds);

            AddToParametersIfHasValue(steamIdsParamValue, "steamids", parameters);

            var playerBansContainer = await CallMethodAsync<PlayerBansContainer>("GetPlayerBans", 1, parameters);
            var playerBansModel = AutoMapperConfiguration.Mapper.Map<IList<PlayerBans>, IList<PlayerBansModel>>(playerBansContainer.PlayerBans);
            return new ReadOnlyCollection<PlayerBansModel>(playerBansModel);
        }

        public async Task<IReadOnlyCollection<long>> GetUserGroupsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(steamId, "steamid", parameters);

            var userGroupResultContainer = await CallMethodAsync<UserGroupListResultContainer>("GetUserGroupList", 1, parameters);

            return userGroupResultContainer.Result.Groups
                .Select(x => x.Gid)
                .ToList()
                .AsReadOnly();
        }

        public async Task<ulong> ResolveVanityUrlAsync(string vanityUrl, int? urlType = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(vanityUrl, "vanityurl", parameters);
            AddToParametersIfHasValue(urlType, "url_type", parameters);

            var vanityUrlResultContainer = await CallMethodAsync<ResolveVanityUrlResultContainer>("ResolveVanityURL", 1, parameters);

            if(vanityUrlResultContainer.Result.Success == 42)
            {
                throw new VanityUrlNotResolvedException(ErrorMessages.VanityUrlNotResolved);
            }

            return vanityUrlResultContainer.Result.SteamId;
        }
    }
}