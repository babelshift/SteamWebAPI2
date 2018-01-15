using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamRemoteStorage : ISteamRemoteStorage
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamRemoteStorage(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ISteamRemoteStorage")
                : steamWebInterface;
        }

        /// <summary>
        /// Retrieves information about published files such as workshop items and screenshots.
        /// </summary>
        /// <param name="itemCount">The quantity of items for which to retrieve details.
        /// This can be smaller than the amount of items in <paramref name="publishedFileIds"/>, but not larger.</param>
        /// <param name="publishedFileIds">The list of ids of files for which to retrieve details.</param>
        /// <returns>A collection of the details of the files or <c>null</c> if the request failed.</returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(uint itemCount, IList<ulong> publishedFileIds) {
            Debug.Assert(itemCount <= publishedFileIds.Count);

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(itemCount, "itemcount");

            for (int i = 0; i < publishedFileIds.Count; ++i)
            {
                parameters.AddIfHasValue(publishedFileIds[i], $"publishedfileids[{i}]");
            }

            try
            {
                var steamWebResponse = await steamWebInterface.PostAsync<PublishedFileDetailsResultContainer>("GetPublishedFileDetails", 1, parameters);

                var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                    ISteamWebResponse<PublishedFileDetailsResultContainer>,
                    ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>>(steamWebResponse);

                return steamWebResponseModel;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about how to download a user generated content based on a UGC ID, App ID, and Steam ID.
        /// </summary>
        /// <param name="ugcId"></param>
        /// <param name="appId"></param>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<UGCFileDetailsModel>> GetUGCFileDetailsAsync(ulong ugcId, uint appId, ulong? steamId = null)
        {
            Debug.Assert(appId > 0);

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(ugcId, "ugcid");
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(steamId, "steamid");

            try
            {
                var steamWebResponse = await steamWebInterface.GetAsync<UGCFileDetailsResultContainer>("GetUGCFileDetails", 1, parameters);

                var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                    ISteamWebResponse<UGCFileDetailsResultContainer>,
                    ISteamWebResponse<UGCFileDetailsModel>>(steamWebResponse);

                return steamWebResponseModel;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}