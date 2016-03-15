using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    internal class SteamStoreRequest
    {
        private string steamStoreApiBaseUrl;

        public SteamStoreRequest(string steamStoreApiBaseUrl)
        {
            if (String.IsNullOrEmpty(steamStoreApiBaseUrl))
            {
                throw new ArgumentNullException("steamStoreApiBaseUrl");
            }

            this.steamStoreApiBaseUrl = steamStoreApiBaseUrl;
        }

        public async Task<T> SendStoreRequestAsync<T>(string endpointName)
        {
            Debug.Assert(!String.IsNullOrEmpty(endpointName));

            return await SendStoreRequestAsync<T>(endpointName, null);
        }

        public async Task<T> SendStoreRequestAsync<T>(string endpointName, IList<SteamWebRequestParameter> parameters)
        {
            Debug.Assert(!String.IsNullOrEmpty(endpointName));

            if (parameters == null)
            {
                parameters = new List<SteamWebRequestParameter>();
            }

            string command = BuildRequestCommand(endpointName, parameters);

            string response = await GetHttpStringResponseAsync(command).ConfigureAwait(false);

            var deserializedResult = JsonConvert.DeserializeObject<T>(response);
            return deserializedResult;
        }

        private static async Task<string> GetHttpStringResponseAsync(string command)
        {
            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(command);
            response = response.Replace("\n", "");
            response = response.Replace("\t", "");
            return response;
        }

        public string BuildRequestCommand(string endpointName, IList<SteamWebRequestParameter> parameters)
        {
            Debug.Assert(!String.IsNullOrEmpty(endpointName));

            if (steamStoreApiBaseUrl.EndsWith("/"))
            {
                steamStoreApiBaseUrl = steamStoreApiBaseUrl.Remove(steamStoreApiBaseUrl.Length - 1, 1);
            }

            string commandUrl = String.Format("{0}/{1}/", steamStoreApiBaseUrl, endpointName);

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
