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
            this.steamWebRequest = new SteamWebRequest(steamWebApiKey);
        }

        /// <summary>
        /// Calls a specific method on whatever interface this class represents. For example "IsPlayingSharedGame" is a method on the "PlayerService" web interface.
        /// </summary>
        /// <typeparam name="T">The type to parse the JSON response into and return</typeparam>
        /// <param name="methodName">The method name to call</param>
        /// <param name="version">The version of the method to call</param>
        /// <param name="parameters">An optional list of parameters to include with the call</param>
        /// <returns></returns>
        internal async Task<T> CallMethodAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(version > 0);

            return await steamWebRequest.SendWebRequestAsync<T>(interfaceName, methodName, version, parameters);
        }

        #region Helpers

        /// <summary>
        /// Checks if the passed nullable value has a value. If it does, it is appended to the parameter list as a key/value pair with "name" as the key.
        /// </summary>
        /// <typeparam name="T">Type of the value to check</typeparam>
        /// <param name="value">Nullable value to check</param>
        /// <param name="name">Name of the key that will be used if the value is appended to the parameter list</param>
        /// <param name="parameters">List of web request parameters that will be used in the building of the request URL</param>
        internal void AddToParametersIfHasValue<T>(T? value, string name, IList<SteamWebRequestParameter> parameters) where T : struct
        {
            if (value.HasValue)
            {
                parameters.Add(new SteamWebRequestParameter(name, value.Value.ToString()));
            }
        }

        /// <summary>
        /// Checks if the passed value is not null. If it is not null, it is appended to the parameter list as a key/value pair with "name" as the key.
        /// </summary>
        /// <typeparam name="T">Type of the value to check</typeparam>
        /// <param name="value">Value to check</param>
        /// <param name="name">Name of the key that will be used if the value is appended to the parameter list</param>
        /// <param name="parameters">List of web request parameters that will be used in the building of the request URL</param>
        internal void AddToParametersIfHasValue<T>(T value, string name, IList<SteamWebRequestParameter> parameters)
        {
            if (value != null)
            {
                parameters.Add(new SteamWebRequestParameter(name, value.ToString()));
            }
        }

        /// <summary>
        /// Checks if the passed string value is not null or empty. If it is not null or empty, it is appended to the parameter list as a key/value pair with "name" as the key.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="name">Name of the key that will be used if the value is appended to the parameter list</param>
        /// <param name="parameters">List of web request parameters that will be used in the building of the request URL</param>
        internal void AddToParametersIfHasValue(string value, string name, IList<SteamWebRequestParameter> parameters)
        {
            if (!String.IsNullOrEmpty(value))
            {
                parameters.Add(new SteamWebRequestParameter(name, value));
            }
        }

        #endregion Helpers
    }
}