using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebRequest
    {
        /// <summary>
        /// Performs a GET request to the provided interface, method, and version with the passed parameters
        /// </summary>
        /// <typeparam name="T">Type to deserialize response</typeparam>
        /// <param name="interfaceName">Name of web API interface to call</param>
        /// <param name="methodName">Name of web API method to call</param>
        /// <param name="methodVersion">Name of web API method version</param>
        /// <param name="parameters">List of parameters to append to the web API call</param>
        /// <returns>Deserialized object from JSON response</returns>
        Task<ISteamWebResponse<T>> GetAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null);

        /// <summary>
        /// Performs a POST request to the provided interface, method, and version with the passed parameters
        /// </summary>
        /// <typeparam name="T">Type to deserialize response</typeparam>
        /// <param name="interfaceName">Name of web API interface to call</param>
        /// <param name="methodName">Name of web API method to call</param>
        /// <param name="methodVersion">Name of web API method version</param>
        /// <param name="parameters">List of parameters to append to the web API call</param>
        /// <returns>Deserialized object from JSON response</returns>
        Task<ISteamWebResponse<T>> PostAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null);
    }
}