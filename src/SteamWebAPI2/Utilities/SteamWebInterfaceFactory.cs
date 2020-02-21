using System;
using System.Net.Http;
using SteamWebAPI2.Interfaces;

namespace SteamWebAPI2.Utilities
{
    public class SteamWebInterfaceFactory
    {
        private readonly string steamWebApiBaseUrl = "https://api.steampowered.com/";
        private string steamWebApiKey;

        /// <summary>
        /// Factory to create web interface objects to communicate with Steam Web API
        /// </summary>
        /// <param name="steamWebApiKey">Unique Steam Web API key issued to you (do not share this with anyone!)</param>
        /// <param name="steamWebApiBaseUrl">Base URL of the Steam Web API (optional)</param>
        public SteamWebInterfaceFactory(string steamWebApiKey, string steamWebApiBaseUrl = null)
        {
            if(string.IsNullOrWhiteSpace(steamWebApiKey))
            {
                throw new ArgumentNullException(nameof(steamWebApiKey));
            }

            this.steamWebApiKey = steamWebApiKey;

            if(!string.IsNullOrWhiteSpace(steamWebApiBaseUrl))
            {
                this.steamWebApiBaseUrl = steamWebApiBaseUrl;
            }
        }

        /// <summary>
        /// Creates a web interface object connected to a specific Steam Web API interfac endpoint
        /// </summary>
        /// <param name="httpClient">Custom http client injected with your customization (if necessary)</param>
        /// <typeparam name="T">Type of the web interface to create</typeparam>
        /// <returns>Instance of the web interface</returns>
        public T CreateSteamWebInterface<T>(HttpClient httpClient)
        {
            var steamWebRequest = CreateSteamWebRequest(httpClient);
            return (T)Activator.CreateInstance(typeof(T), steamWebRequest, null);
        }

                /// <summary>
        /// Creates a web interface object connected to a specific Steam Web API interfac endpoint
        /// </summary>
        /// <param name="httpClient">Custom http client injected with your customization (if necessary)</param>
        /// <typeparam name="T">Type of the web interface to create</typeparam>
        /// <returns>Instance of the web interface</returns>
        public T CreateSteamWebInterface<T>(HttpClient httpClient, EconItemsAppId appId)
        {
            var steamWebRequest = CreateSteamWebRequest(httpClient);
            return (T)Activator.CreateInstance(typeof(T), steamWebRequest, appId, null);
        }

        private ISteamWebRequest CreateSteamWebRequest(HttpClient httpClient)
        {
            SteamWebHttpClient steamWebHttpClient = new SteamWebHttpClient(httpClient);
            return new SteamWebRequest(steamWebApiBaseUrl, steamWebApiKey, steamWebHttpClient);
        }
    }
}