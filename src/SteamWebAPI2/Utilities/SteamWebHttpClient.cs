using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    /// <summary>
    /// Wraps HttpClient for convenience and testability. Note that newlines and tabs are stripped from responses.
    /// </summary>
    internal class SteamWebHttpClient : ISteamWebHttpClient
    {
        /// <summary>
        /// Performs an HTTP GET with the passed URL command.
        /// </summary>
        /// <param name="command">URL command for GET operation</param>
        /// <returns>String response such as JSON or XML</returns>
        public async Task<HttpResponseMessage> GetAsync(string command)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(command));

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(command);

            response.EnsureSuccessStatusCode();

            if (response.Content == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            return response;
        }

        /// <summary>
        /// Performs an HTTP POST with the passed URL command.
        /// </summary>
        /// <param name="command">URL command for POST operation</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <returns>String response such as JSON or XML</returns>
        public async Task<HttpResponseMessage> PostAsync(string command, HttpContent content)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(command));

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(command, content);

            response.EnsureSuccessStatusCode();

            if (response.Content == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            return response;
        }
    }
}