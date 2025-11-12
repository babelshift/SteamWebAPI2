using Microsoft.Extensions.Options;
using SteamWebAPI2.Interfaces;
using System;
using System.Net.Http;

namespace SteamWebAPI2.Utilities
{
    public class SteamWebInterfaceFactory : ISteamWebInterfaceFactory
    {
        private readonly string steamWebApiBaseUrl = "https://api.steampowered.com/";
        private readonly string steamWebApiKey;

        /// <summary>
        /// Backwards compatible constructor that works with just a Steam Web API key instead of forcing
        /// all consumers to use the IOptions constructor with dependency injection.
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamWebInterfaceFactory(string steamWebApiKey) 
            : this(Options.Create(new SteamWebInterfaceFactoryOptions() 
            { 
                SteamWebApiKey = steamWebApiKey
            })
        ) { }

        /// <summary>
        /// Factory to create web interface objects to communicate with Steam Web API
        /// </summary>
        /// <param name="steamWebApiKey">Unique Steam Web API key issued to you (do not share this with anyone!)</param>
        /// <param name="steamWebApiBaseUrl">Base URL of the Steam Web API (optional)</param>
        public SteamWebInterfaceFactory(IOptions<SteamWebInterfaceFactoryOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrWhiteSpace(options.Value.SteamWebApiKey))
            {
                throw new ArgumentNullException(nameof(options.Value.SteamWebApiKey));
            }

            this.steamWebApiKey = options.Value.SteamWebApiKey;

            if (!string.IsNullOrWhiteSpace(options.Value.SteamWebApiBaseUrl))
            {
                this.steamWebApiBaseUrl = options.Value.SteamWebApiBaseUrl;
            }
        }

        public SteamStore CreateSteamStoreInterface(HttpClient httpClient = null)
        {
            return new SteamStore(httpClient);
        }

        /// <summary>
        /// Creates a web interface object connected to a specific Steam Web API interface endpoint
        /// </summary>
        /// <param name="httpClient">Custom http client injected with your customization (if necessary). 
        /// If null, new instance is created with all defaults.</param>
        /// <typeparam name="T">Type of the web interface to create</typeparam>
        /// <returns>Instance of the web interface</returns>
        public T CreateSteamWebInterface<T>(HttpClient httpClient = null)
        {
            var steamWebRequest = CreateSteamWebRequest(httpClient);
            return (T)Activator.CreateInstance(typeof(T), steamWebRequest, null);
        }

        /// <summary>
        /// Creates a web interface object connected to a specific Steam Web API interface endpoint
        /// </summary>
        /// <param name="appId">Indicates which app to use</param>
        /// <param name="httpClient">Custom http client injected with your customization (if necessary).
        /// If null, new instance is created with all defaults.</param>
        /// <typeparam name="T">Type of the web interface to create</typeparam>
        /// <returns>Instance of the web interface</returns>
        public T CreateSteamWebInterface<T>(AppId appId, HttpClient httpClient = null)
        {
            var steamWebRequest = CreateSteamWebRequest(httpClient);
            return (T)Activator.CreateInstance(typeof(T), steamWebRequest, appId, null);
        }

        private ISteamWebRequest CreateSteamWebRequest(HttpClient httpClient)
        {
            return new SteamWebRequest(steamWebApiBaseUrl, steamWebApiKey, httpClient ?? new HttpClient());
        }
    }
}