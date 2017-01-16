using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebHttpClient
    {
        /// <summary>
        /// Performs an HTTP GET with the passed URL command.
        /// </summary>
        /// <param name="command">URL command for GET operation</param>
        /// <returns>String response such as JSON or XML</returns>
        Task<string> GetStringAsync(string uri);

        /// <summary>
        /// Performs an HTTP POST with the passed URL command.
        /// </summary>
        /// <param name="command">URL command for POST operation</param>
        /// <returns>String response such as JSON or XML</returns>
        Task<string> PostAsync(string uri);
    }
}