using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    /// <summary>
    /// Represents a single "interface" that is exposed as part of the Valve Steam Web API. For example, an interface would be: "IDOTA2Match_570" which contains
    /// methods "GetLeagueListing", "GetMatchDetails", and more. A web interface can be thought of as a class which contains methods to perform GET and POST requests against.
    /// </summary>
    public abstract class SteamWebInterface
    {
        private const string steamWebApiBaseUrl = "https://api.steampowered.com/";
        private readonly SteamWebRequest steamWebRequest;
        private readonly string interfaceName;

        /// <summary>
        /// Default constructor requires a Steam Web API key (secret to each developer) and the name for this web interface (such as "IDOTA2Match_570).
        /// </summary>
        /// <param name="steamWebApiKey">Steam Web API key (secret to each developer)</param>
        /// <param name="interfaceName">Name for this web interface (such as "IDOTA2Match_570). Must match the Steam Web API interface name exactly as this value
        /// is used to construct the URL to perform the GET or POST.</param>
        public SteamWebInterface(string steamWebApiKey, string interfaceName)
        {
            if (String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("steamWebApiKey");
            }

            Debug.Assert(!String.IsNullOrEmpty(interfaceName));

            this.interfaceName = interfaceName;
            this.steamWebRequest = new SteamWebRequest(steamWebApiBaseUrl, steamWebApiKey);

            AutoMapperConfiguration.Initialize();
        }
        
        /// <summary>
        /// Default constructor requires a Steam Web API key (secret to each developer) and the name for this web interface (such as "IDOTA2Match_570).
        /// </summary>
        /// <param name="steamWebApiBaseUrl">Used to override the base URL of each web request. Default is 'https://api.steampowered.com/'.</param>
        /// <param name="steamWebApiKey">Steam Web API key (secret to each developer)</param>
        /// <param name="interfaceName">Name for this web interface (such as "IDOTA2Match_570). Must match the Steam Web API interface name exactly as this value
        /// is used to construct the URL to perform the GET or POST.</param>
        public SteamWebInterface(string steamWebApiBaseUrl, string steamWebApiKey, string interfaceName)
        {
            if (String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("steamWebApiKey");
            }

            Debug.Assert(!String.IsNullOrEmpty(interfaceName));

            this.interfaceName = interfaceName;
            this.steamWebRequest = new SteamWebRequest(steamWebApiBaseUrl, steamWebApiKey);

            AutoMapperConfiguration.Initialize();
        }

        /// <summary>
        /// Calls a specific GET method on whatever interface this class represents. For example "IsPlayingSharedGame" is a method on the "PlayerService" web interface.
        /// </summary>
        /// <typeparam name="T">The type to parse the JSON response into and return</typeparam>
        /// <param name="methodName">The method name to call</param>
        /// <param name="version">The version of the method to call</param>
        /// <param name="parameters">An optional list of parameters to include with the call</param>
        /// <returns></returns>
        internal async Task<T> GetAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(version > 0);

            return await steamWebRequest.GetAsync<T>(interfaceName, methodName, version, parameters);
        }

        /// <summary>
        /// Calls a specific POST method on whatever interface this class represents. For example "IsPlayingSharedGame" is a method on the "PlayerService" web interface.
        /// </summary>
        /// <typeparam name="T">The type to parse the JSON response into and return</typeparam>
        /// <param name="methodName">The method name to call</param>
        /// <param name="version">The version of the method to call</param>
        /// <param name="parameters">An optional list of parameters to include with the call</param>
        /// <returns></returns>
        internal async Task<T> PostAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(version > 0);

            return await steamWebRequest.PostAsync<T>(interfaceName, methodName, version, parameters);
        }
    }
}