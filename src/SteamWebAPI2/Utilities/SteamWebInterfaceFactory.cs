using AutoMapper;
using Microsoft.Extensions.Options;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Mappings;
using System;
using System.Net.Http;

namespace SteamWebAPI2.Utilities
{
    public class SteamWebInterfaceFactory : ISteamWebInterfaceFactory
    {
        private readonly string steamWebApiBaseUrl = "https://api.steampowered.com/";
        private readonly string steamWebApiKey;
        private readonly IMapper mapper;

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

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<SteamWebResponseProfile>();
                config.AddProfile<DOTA2EconProfile>();
                config.AddProfile<DOTA2FantasyProfile>();
                config.AddProfile<DOTA2MatchProfile>();
                config.AddProfile<EconServiceProfile>();
                config.AddProfile<SteamEconomyProfile>();
                config.AddProfile<SteamStoreProfile>();
                config.AddProfile<SteamProfileProfile>();
                config.AddProfile<GameServersProfile>();
                config.AddProfile<PlayerServiceProfile>();
                config.AddProfile<SteamRemoteStorageProfile>();
                config.AddProfile<SteamUserProfile>();
                config.AddProfile<SteamUserStatsProfile>();
                config.AddProfile<GCVersionProfile>();
                config.AddProfile<SteamAppsProfile>();
                config.AddProfile<SteamWebAPIUtilProfile>();
                config.AddProfile<TFItemsProfile>();
                config.AddProfile<SteamNewsProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        public SteamStore CreateSteamStoreInterface(HttpClient httpClient = null)
        {
            if(httpClient == null)
            {
                return new SteamStore(mapper);
            }

            return new SteamStore(mapper, httpClient);
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
            return (T)Activator.CreateInstance(typeof(T), mapper, steamWebRequest, null);
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
            return (T)Activator.CreateInstance(typeof(T), mapper, steamWebRequest, appId, null);
        }

        private ISteamWebRequest CreateSteamWebRequest(HttpClient httpClient)
        {
            return new SteamWebRequest(steamWebApiBaseUrl, steamWebApiKey, httpClient ?? new HttpClient());
        }
    }
}