using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebHttpClient
    {
        /// <summary>
        /// Performs an HTTP GET with the passed URL command.
        /// </summary>
        /// <param name="uri">URL command for GET operation</param>
        /// <returns>String response such as JSON or XML</returns>
        Task<HttpResponseMessage> GetAsync(string uri);

        /// <summary>
        /// Performs an HTTP POST with the passed URL command.
        /// </summary>
        /// <param name="uri">URL command for POST operation</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <returns>String response such as JSON or XML</returns>
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent content);
    }
}