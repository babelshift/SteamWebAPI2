﻿using AutoMapper;
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
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamRemoteStorage(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamRemoteStorage", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Retrieves the list of items in the provided collection.
        /// </summary>
        /// <param name="collectionId">The collection's ID.</param>
        /// <returns>A collection of the details of each collection or <c>null</c> if the request failed.</returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<CollectionDetail>>> GetCollectionDetails(ulong collectionId) => await GetCollectionDetails(new List<ulong> { collectionId });

        /// <summary>
        /// Retrieves the list of items in the provided collections.
        /// </summary>
        /// <param name="collectionIds">The list of IDs of collections for which to retrieve details.</param>
        /// <returns>A collection of the details of each collection or <c>null</c> if the request failed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="collectionIds"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="collectionIds"/> is empty.</exception>
        public async Task<ISteamWebResponse<IReadOnlyCollection<CollectionDetail>>> GetCollectionDetails(IList<ulong> collectionIds)
        {
            if (collectionIds == null)
                throw new ArgumentNullException(nameof(collectionIds));

            if (!collectionIds.Any())
                throw new ArgumentOutOfRangeException(nameof(collectionIds), $"{nameof(collectionIds)} is empty.");

            IList<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(collectionIds.Count, "collectioncount");

            for (int i = 0; i < collectionIds.Count; ++i)
                parameters.AddIfHasValue(collectionIds[i], $"publishedfileids[{i}]");

            try
            {
                var steamWebResponse = await steamWebInterface.PostAsync<CollectionDetailsResponseContainer>("GetCollectionDetails", 1, parameters);

                var steamWebResponseModel = mapper.Map<
                    ISteamWebResponse<CollectionDetailsResponseContainer>,
                    ISteamWebResponse<IReadOnlyCollection<CollectionDetail>>>(steamWebResponse);

                return steamWebResponseModel;
            }
            catch (HttpRequestException)
            {
                return null;
            }
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
        public async Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(uint itemCount, IList<ulong> publishedFileIds)
        {
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

                var steamWebResponseModel = mapper.Map<
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
        private async Task<ISteamWebResponse<TData>> GetPublishedFileDetailsAsync<TData>(IList<SteamWebRequestParameter> parameters)
        {
            try
            {
                var steamWebResponse = await steamWebInterface.PostAsync<PublishedFileDetailsResultContainer>("GetPublishedFileDetails", 1, parameters);

                var steamWebResponseModel = mapper.Map<
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