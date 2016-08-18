using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using SteamWebAPI2.Exceptions;
using SteamWebAPI2.Utilities;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUser : SteamWebInterface, ISteamUser
    {
        public SteamUser(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUser")
        { }

        /// <summary>
        /// Returns a summary of some player and Steam User information such as their Steam Profile data.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<PlayerSummaryModel> GetPlayerSummaryAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamids");

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

        public async Task<List<PlayerSummaryModel>> GetPlayerSummariesAsync(List<long> steamIds)
        {
            // convert steam ids to a csv for the api
            var steamIdsCsv = string.Join(",", steamIds.Select(x => x.ToString()).ToArray());
            var parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamIdsCsv, "steamids");

            var playerSummaries = await CallMethodAsync<PlayerSummaryResultContainer>("GetPlayerSummaries", 2, parameters);
            if (playerSummaries.Result.Players != null && playerSummaries.Result.Players.Count > 0)
                return playerSummaries.Result.Players.Select(player => AutoMapperConfiguration.Mapper.Map<PlayerSummary, PlayerSummaryModel>(player)).ToList();

            return null;
        }

        /// <summary>
        /// Returns a collection of a specific Steam User's friends list.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="relationship"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<FriendModel>> GetFriendsListAsync(long steamId, string relationship = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(relationship, "relationship");

            var friendsListResult = await CallMethodAsync<FriendsListResultContainer>("GetFriendList", 1, parameters);

            var friendsListModel = AutoMapperConfiguration.Mapper.Map<IList<Friend>, IList<FriendModel>>(friendsListResult.Result.Friends);

            return new ReadOnlyCollection<FriendModel>(friendsListModel);
        }

        /// <summary>
        /// Returns a collection of a specific Steam User's VAC bans.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(long steamId)
        {
            var result = await GetPlayerBansAsync(new List<long>() { steamId });
            return result;
        }

        /// <summary>
        /// Returns a collection of a collection of Steam User's VAC bans.
        /// </summary>
        /// <param name="steamIds"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(IReadOnlyCollection<long> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            string steamIdsParamValue = String.Join(",", steamIds);

            parameters.AddIfHasValue(steamIdsParamValue, "steamids");

            var playerBansContainer = await CallMethodAsync<PlayerBansContainer>("GetPlayerBans", 1, parameters);
            var playerBansModel = AutoMapperConfiguration.Mapper.Map<IList<PlayerBans>, IList<PlayerBansModel>>(playerBansContainer.PlayerBans);
            return new ReadOnlyCollection<PlayerBansModel>(playerBansModel);
        }

        /// <summary>
        /// Returns a collection of a specific Steam User's community groups.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<long>> GetUserGroupsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");

            var userGroupResultContainer = await CallMethodAsync<UserGroupListResultContainer>("GetUserGroupList", 1, parameters);

            return userGroupResultContainer.Result.Groups
                .Select(x => x.Gid)
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Returns the 64-bit Steam ID of a Steam User based on their "Vanity URL" (which is their custom community profile name).
        /// </summary>
        /// <param name="vanityUrl"></param>
        /// <param name="urlType"></param>
        /// <returns></returns>
        public async Task<ulong> ResolveVanityUrlAsync(string vanityUrl, int? urlType = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(vanityUrl, "vanityurl");
            parameters.AddIfHasValue(urlType, "url_type");

            var vanityUrlResultContainer = await CallMethodAsync<ResolveVanityUrlResultContainer>("ResolveVanityURL", 1, parameters);

            if(vanityUrlResultContainer.Result.Success == 42)
            {
                throw new VanityUrlNotResolvedException(ErrorMessages.VanityUrlNotResolved);
            }

            return vanityUrlResultContainer.Result.SteamId;
        }

        /// <summary>
        /// Returns a community profile data based on parsing the XML of a Steam User's Community Profile.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<SteamCommunityProfileModel> GetCommunityProfileAsync(long steamId)
        {
            HttpClient httpClient = new HttpClient();
            string xml = await httpClient.GetStringAsync(String.Format("http://steamcommunity.com/profiles/{0}?xml=1", steamId));

            var profile = DeserializeXML<SteamCommunityProfile>(xml);

            var profileModel = AutoMapperConfiguration.Mapper.Map<SteamCommunityProfile, SteamCommunityProfileModel>(profile);

            return profileModel;
        }

        private static T DeserializeXML<T>(string xml)
        {
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(stream);
            }
        }
    }
}