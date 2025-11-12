using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    internal class SteamWebRequest : ISteamWebRequest
    {
        private readonly string steamWebApiBaseUrl;
        private readonly string steamWebApiKey;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Every web request requires a secret Steam Web API key
        /// </summary>
        /// <param name="steamWebApiBaseUrl">Base URL for the API (such as http://api.steampowered.com)</param>
        /// <param name="steamWebApiKey">Secret Steam Web API key provided at the Valve developer website</param>
        /// <param name="steamWebHttpClient">Optional custom http client implementation for dependency injection</param>
        public SteamWebRequest(string steamWebApiBaseUrl, string steamWebApiKey, HttpClient httpClient = null)
        {
            if (string.IsNullOrWhiteSpace(steamWebApiBaseUrl))
            {
                throw new ArgumentNullException(nameof(steamWebApiBaseUrl));
            }

            if (string.IsNullOrWhiteSpace(steamWebApiKey))
            {
                throw new ArgumentNullException(nameof(steamWebApiKey));
            }

            this.steamWebApiBaseUrl = steamWebApiBaseUrl;
            this.steamWebApiKey = steamWebApiKey;
            this.httpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Performs a GET request to the provided interface, method, and version with the passed parameters
        /// </summary>
        /// <typeparam name="T">Type to deserialize response</typeparam>
        /// <param name="interfaceName">Name of web API interface to call</param>
        /// <param name="methodName">Name of web API method to call</param>
        /// <param name="methodVersion">Name of web API method version</param>
        /// <param name="parameters">List of parameters to append to the web API call</param>
        /// <returns>Deserialized object from JSON response</returns>
        public async Task<ISteamWebResponse<T>> GetAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null)
        {
            return await SendWebRequestAsync<T>(HttpMethod.GET, interfaceName, methodName, methodVersion, parameters);
        }

        /// <summary>
        /// Performs a POST request to the provided interface, method, and version with the passed parameters
        /// </summary>
        /// <typeparam name="T">Type to deserialize response</typeparam>
        /// <param name="interfaceName">Name of web API interface to call</param>
        /// <param name="methodName">Name of web API method to call</param>
        /// <param name="methodVersion">Name of web API method version</param>
        /// <param name="parameters">List of parameters to append to the web API call</param>
        /// <returns>Deserialized object from JSON response</returns>
        public async Task<ISteamWebResponse<T>> PostAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null)
        {
            return await SendWebRequestAsync<T>(HttpMethod.POST, interfaceName, methodName, methodVersion, parameters);
        }

        /// <summary>
        /// Returns an object of type T created from the deserialization of the JSON response to the passed interface/method/version with the included parameters.
        /// </summary>
        /// <typeparam name="T">Type to deserialize into</typeparam>
        /// <param name="httpMethod">Determines GET or POST request</param>
        /// <param name="interfaceName">Name of web API interface to call</param>
        /// <param name="methodName">Name of web API method to call</param>
        /// <param name="methodVersion">Name of web API method version</param>
        /// <param name="parameters">List of parameters to append to the web API call</param>
        /// <returns>Deserialized object from JSON response</returns>
        private async Task<ISteamWebResponse<T>> SendWebRequestAsync<T>(HttpMethod httpMethod, string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null)
        {
            if (string.IsNullOrWhiteSpace(interfaceName))
            {
                throw new ArgumentNullException(nameof(interfaceName));
            }

            if (string.IsNullOrWhiteSpace(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }

            if (methodVersion <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(methodVersion));
            }

            if (parameters == null)
            {
                parameters = new List<SteamWebRequestParameter>();
            }

            parameters.Insert(0, new SteamWebRequestParameter("key", steamWebApiKey));
            //parameters.Insert(0, new SteamWebRequestParameter("feeds", "SteamDB")); -- Demonstration of Implementing Feeds Parameter
            //parameters.Insert(0, new SteamWebRequestParameter("tags", "halloween")); -- Demonstration of Implementing Tags Parameter

            HttpResponseMessage httpResponse = null;

            if (httpMethod == HttpMethod.GET)
            {
                string command = BuildRequestCommand(interfaceName, methodName, methodVersion, parameters);

                httpResponse = await httpClient.GetAsync(command).ConfigureAwait(false);
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content == null)
                {
                    httpResponse = new HttpResponseMessage(HttpStatusCode.NoContent);
                }
            }
            else if (httpMethod == HttpMethod.POST)
            {
                // Null is passed instead of the parameters so that they are not appended to the URL.
                string command = BuildRequestCommand(interfaceName, methodName, methodVersion, null);

                // Instead, parameters are passed through this container.
                FormUrlEncodedContent content = BuildRequestContent(parameters);

                httpResponse = await httpClient.PostAsync(command, content).ConfigureAwait(false);
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content == null)
                {
                    httpResponse = new HttpResponseMessage(HttpStatusCode.NoContent);
                }
            }

            var headers = httpResponse.Content?.Headers;

            // extract http headers that we care about
            SteamWebResponse<T> steamWebResponse = new SteamWebResponse<T>()
            {
                ContentLength = headers?.ContentLength,
                ContentType = headers?.ContentType?.MediaType,
                ContentTypeCharSet = headers?.ContentType?.CharSet,
                Expires = headers?.Expires,
                LastModified = headers?.LastModified,
            };

            // deserialize the content if we have any as indicated by the response code
            if (httpResponse.StatusCode != HttpStatusCode.NoContent && httpResponse.Content != null)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync();
                responseContent = CleanupResponseString(responseContent);
                steamWebResponse.Data = JsonConvert.DeserializeObject<T>(responseContent);
            }

            return steamWebResponse;
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
        private string BuildRequestCommand(string interfaceName, string methodName, int methodVersion, IEnumerable<SteamWebRequestParameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(interfaceName))
            {
                throw new ArgumentNullException(nameof(interfaceName));
            }

            if (string.IsNullOrWhiteSpace(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }

            if (methodVersion <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(methodVersion));
            }

            if (parameters == null)
            {
                parameters = new List<SteamWebRequestParameter>();
            }

            string steamWebApiUrl = steamWebApiBaseUrl;
            if (steamWebApiBaseUrl.EndsWith("/"))
            {
                steamWebApiUrl = steamWebApiUrl.Remove(steamWebApiUrl.Length - 1, 1);
            }

            string commandUrl = $"{steamWebApiUrl}/{interfaceName}/{methodName}/v{methodVersion}/";

            // if we have parameters, join them together with & delimiter and append them to the command URL
            if (parameters != null && parameters.Count() > 0)
            {
                string parameterString = string.Join("&", parameters);
                commandUrl += $"?{parameterString}";
            }

            return commandUrl;
        }

        /// <summary>
        /// Encodes request parameters using application/x-www-form-urlencoded MIME type.
        /// The resulting container enables parameters to be sent properly in a POST request.
        /// </summary>
        /// <param name="parameters">Example: { key: 8A05823474AB641D684EBD95AB5F2E47 } </param>
        /// <returns></returns>
        private static FormUrlEncodedContent BuildRequestContent(IEnumerable<SteamWebRequestParameter> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (!parameters.Any())
            {
                parameters = new List<SteamWebRequestParameter>();
            }

            if (parameters != null && parameters.Count() > 0)
            {
                return new FormUrlEncodedContent(parameters.ToDictionary(p => p.Name, p => p.Value));
            }

            return null;
        }

        /// <summary>
        /// Sends a http request to the command URL and returns the string response.
        /// </summary>
        /// <param name="stringToClean">Command URL to send</param>
        /// <returns>String containing the http endpoint response contents</returns>
        private static string CleanupResponseString(string stringToClean)
        {
            if (string.IsNullOrWhiteSpace(stringToClean))
            {
                return string.Empty;
            }

            stringToClean = stringToClean.Replace("\n", "");
            stringToClean = stringToClean.Replace("\t", "");

            return stringToClean;
        }
    }
}