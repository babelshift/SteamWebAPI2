using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        /// <param name="publishedFileIds">The list of IDs of files for which to retrieve details.</param>
        /// <returns>A collection of the details of each file or <c>null</c> if the request failed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="publishedFileIds"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="publishedFileIds"/> is empty or <paramref name="itemCount"/>is greater than the number of elements in <paramref name="publishedFileIds"/>.</exception>
        public async Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(uint itemCount, IList<ulong> publishedFileIds) {
            if (publishedFileIds == null)
            {
                throw new ArgumentNullException(nameof(publishedFileIds));
            }

            if (!publishedFileIds.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(publishedFileIds), $"{nameof(publishedFileIds)} is empty.");
            }

            if (itemCount > publishedFileIds.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(itemCount), itemCount, $"{nameof(itemCount)} cannot be greater than the number of elements in {nameof(publishedFileIds)}.");
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(itemCount, "itemcount");

            for (int i = 0; i < publishedFileIds.Count; ++i)
            {
                parameters.AddIfHasValue(publishedFileIds[i], $"publishedfileids[{i}]");
            }

            return await GetPublishedFileDetailsAsync<IReadOnlyCollection<PublishedFileDetailsModel>>(parameters);
        }

        /// <summary>
        /// Retrieves information about published files such as workshop items and screenshots.
        /// </summary>
        /// <param name="publishedFileIds">The list of IDs of files for which to retrieve details.</param>
        /// <returns>A collection of the details of each file or <c>null</c> if the request failed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="publishedFileIds"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="publishedFileIds"/> is empty.</exception>
        public async Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(IList<ulong> publishedFileIds)
        {
            if (publishedFileIds == null)
            {
                throw new ArgumentNullException(nameof(publishedFileIds));
            }

            return await GetPublishedFileDetailsAsync((uint)publishedFileIds.Count, publishedFileIds);
        }

        /// <summary>
        /// Retrieves information about a published file such as a workshop item or screenshot.
        /// </summary>
        /// <param name="publishedFileId">The ID of the file for which to retrieve details.</param>
        /// <returns>The details of the file or <c>null</c> if the request failed.</returns>
        public async Task<ISteamWebResponse<PublishedFileDetailsModel>> GetPublishedFileDetailsAsync(ulong publishedFileId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(1, "itemcount");
            parameters.AddIfHasValue(publishedFileId, "publishedfileids[0]");

            return await GetPublishedFileDetailsAsync<PublishedFileDetailsModel>(parameters);
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

        /// <summary>
        /// Sends a request to GetPublishedFileDetails and maps the response's data to <typeparamref name="TData"/>.
        /// </summary>
        /// <typeparam name="TData">The type to which to map the data of the response.</typeparam>
        /// <param name="parameters">The parameters of the request.</param>
        /// <returns>The response of the request to the API or <c>null</c> if the request failed.</returns>
        private async Task<ISteamWebResponse<TData>> GetPublishedFileDetailsAsync<TData>(IList<SteamWebRequestParameter> parameters) {
            try
            {
                var steamWebResponse = await steamWebInterface.PostAsync<PublishedFileDetailsResultContainer>("GetPublishedFileDetails", 1, parameters);

                var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                    ISteamWebResponse<PublishedFileDetailsResultContainer>,
                    ISteamWebResponse<TData>>(steamWebResponse);

                return steamWebResponseModel;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}