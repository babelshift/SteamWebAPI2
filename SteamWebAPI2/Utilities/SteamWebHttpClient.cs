using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    internal class SteamWebHttpClient : ISteamWebHttpClient
    {
        /// <summary>
        /// Performs an HTTP GET with the passed URL command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> GetStringAsync(string command)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(command));

            HttpClient httpClient = new HttpClient();
            string responseContent = await httpClient.GetStringAsync(command);
            return CleanupResponseString(responseContent);
        }

        /// <summary>
        /// Performs an HTTP POST with the passed URL command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string command)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(command));

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(command, null);

            if(response == null || response.Content == null)
            {
                return String.Empty;
            }

            string responseContent = await response.Content.ReadAsStringAsync();

            return CleanupResponseString(responseContent);
        }

        /// <summary>
        /// Sends a http request to the command URL and returns the string response.
        /// </summary>
        /// <param name="stringToClean">Command URL to send</param>
        /// <returns>String containing the http endpoint response contents</returns>
        private static string CleanupResponseString(string stringToClean)
        {
            if (String.IsNullOrWhiteSpace(stringToClean))
            {
                return String.Empty;
            }

            stringToClean = stringToClean.Replace("\n", "");
            stringToClean = stringToClean.Replace("\t", "");

            return stringToClean;
        }
    }
}