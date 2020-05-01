using AutoMapper;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    /// <summary>
    /// Represents an interface into the Steam Store Web API
    /// </summary>
    public abstract class SteamStoreInterface
    {
        private const string steamStoreApiBaseUrl = "http://store.steampowered.com/api/";
        private readonly SteamStoreRequest steamStoreRequest;

        protected readonly IMapper mapper;

        /// <summary>
        /// Constructs and maps the default objects for Steam Store Web API use
        /// </summary>
        public SteamStoreInterface(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl);
        }

        /// <summary>
        /// Constructs and maps based on a custom http client
        /// </summary>
        /// <param name="httpClient">Client to make requests with</param>
        public SteamStoreInterface(IMapper mapper, HttpClient httpClient)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl, httpClient);
        }

        /// <summary>
        /// Constructs and maps based on a custom Steam Store Web API URL
        /// </summary>
        /// <param name="steamStoreApiBaseUrl">Steam Store Web API URL</param>
        public SteamStoreInterface(string steamStoreApiBaseUrl)
        {
            steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl);
        }

        /// <summary>
        /// Constructs and maps based on a custom http client and custom Steam Store Web API URL
        /// </summary>
        /// <param name="steamStoreApiBaseUrl">Steam Store Web API URL</param>
        /// <param name="httpClient">Client to make requests with</param>
        public SteamStoreInterface(string steamStoreApiBaseUrl, HttpClient httpClient)
        {
            steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl, httpClient);
        }

        /// <summary>
        /// Calls a endpoint on the constructed Web API with parameters
        /// </summary>
        /// <typeparam name="T">Type of object which will be deserialized from the response</typeparam>
        /// <param name="endpointName">Endpoint to call on the interface</param>
        /// <param name="parameters">Parameters to pass to the endpoint</param>
        /// <returns>Deserialized response object</returns>
        internal async Task<T> CallMethodAsync<T>(string endpointName, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!string.IsNullOrEmpty(endpointName));

            return await steamStoreRequest.SendStoreRequestAsync<T>(endpointName, parameters);
        }
    }
}