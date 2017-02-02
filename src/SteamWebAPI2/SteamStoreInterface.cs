using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        private readonly string endpointName;

        /// <summary>
        /// Constructs and maps the default objects for Steam Store Web API use
        /// </summary>
        public SteamStoreInterface()
        {
            this.steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl);

            AutoMapperConfiguration.Initialize();
        }

        /// <summary>
        /// Constructs and maps based on a custom Steam Store Web API URL
        /// </summary>
        /// <param name="steamStoreApiBaseUrl">Steam Store Web API URL</param>
        public SteamStoreInterface(string steamStoreApiBaseUrl)
        {
            this.steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl);

            AutoMapperConfiguration.Initialize();
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
            Debug.Assert(!String.IsNullOrEmpty(endpointName));

            return await steamStoreRequest.SendStoreRequestAsync<T>(endpointName, parameters);
        }
    }
}
