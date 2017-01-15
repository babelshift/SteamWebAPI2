using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    internal enum HttpMethod
    {
        GET,
        POST
    }

    /// <summary>
    /// Represents a http web request to be sent to the Steam Web API remote endpoint. A web request functions by building a command URL from a base address,
    /// an interface name, a method name, a method version, and a list of parameter values. Web requests can return JSON, XML, or VDF formats, but this class
    /// currently only supports JSON deserialization.
    /// </summary>
    public class SteamWebRequest : ISteamWebRequest
    {
        private string steamWebApiBaseUrl;
        private readonly string steamWebApiKey;
        private ISteamWebHttpClient httpClient;

        /// <summary>
        /// Every web request requires a secret Steam Web API key
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamWebRequest(string steamWebApiBaseUrl, string steamWebApiKey, ISteamWebHttpClient httpClient = null)
        {
            this.httpClient = httpClient == null ? new SteamWebHttpClient() : httpClient;

            if (String.IsNullOrEmpty(steamWebApiBaseUrl))
            {
                throw new ArgumentNullException("steamWebApiBaseUrl");
            }

            if (String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("steamWebApiKey");
            }

            this.steamWebApiBaseUrl = steamWebApiBaseUrl;
            this.steamWebApiKey = steamWebApiKey;
        }

        public async Task<T> GetAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null)
        {
            return await SendWebRequestAsync<T>(HttpMethod.GET, interfaceName, methodName, methodVersion, parameters);
        }

        public async Task<T> PostAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null)
        {
            return await SendWebRequestAsync<T>(HttpMethod.POST, interfaceName, methodName, methodVersion, parameters);
        }

        /// <summary>
        /// Returns an object of type T created from the deserialization of the JSON response to the passed interface/method/version with the included parameters.
        /// </summary>
        /// <typeparam name="T">Type to deserialize into</typeparam>
        /// <param name="interfaceName">Name of web API interface to call</param>
        /// <param name="methodName">Name of web API method to call</param>
        /// <param name="methodVersion">Name of web API method version</param>
        /// <param name="parameters">List of parameters to append to the web API call</param>
        /// <returns>Deserialized object from JSON response</returns>
        private async Task<T> SendWebRequestAsync<T>(HttpMethod httpMethod, string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(interfaceName));
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(methodVersion > 0);

            if (parameters == null)
            {
                parameters = new List<SteamWebRequestParameter>();
            }

            parameters.Insert(0, new SteamWebRequestParameter("key", steamWebApiKey));

            string command = BuildRequestCommand(interfaceName, methodName, methodVersion, parameters);

            string response = String.Empty;

            if (httpMethod == HttpMethod.GET)
            {
                response = await httpClient.GetStringAsync(command).ConfigureAwait(false);
            }
            else if (httpMethod == HttpMethod.POST)
            {
                response = await httpClient.PostAsync(command).ConfigureAwait(false);
            }

            var deserializedResult = JsonConvert.DeserializeObject<T>(response);

            return deserializedResult;
        }

        /// <summary>
        /// Takes values and returns a command string that can be sent to a Steam Web API remote address.
        /// Example of a built command: https://api.steampowered.com/ISteamWebAPIUtil/GetSupportedAPIList/v0001/?key=8A05823474AB641D684EBD95AB5F2E47
        /// </summary>
        /// <param name="interfaceName">Example: ISteamWebAPIUtil</param>
        /// <param name="methodName">Example: GetSupportedAPIList</param>
        /// <param name="methodVersion">Example: 1</param>
        /// <param name="parameters">Example: { key: 8A05823474AB641D684EBD95AB5F2E47 } </param>
        /// <returns></returns>
        private string BuildRequestCommand(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters)
        {
            Debug.Assert(!String.IsNullOrEmpty(interfaceName));
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(methodVersion > 0);

            if (steamWebApiBaseUrl.EndsWith("/"))
            {
                steamWebApiBaseUrl = steamWebApiBaseUrl.Remove(steamWebApiBaseUrl.Length - 1, 1);
            }

            string commandUrl = String.Format("{0}/{1}/{2}/v{3}/", steamWebApiBaseUrl, interfaceName, methodName, methodVersion);

            // if we have parameters, join them together with & delimiter and append them to the command URL
            if (parameters != null && parameters.Count > 0)
            {
                string parameterString = String.Join("&", parameters);
                commandUrl += String.Format("?{0}", parameterString);
            }

            return commandUrl;
        }
    }
}