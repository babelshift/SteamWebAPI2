using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebInterface
    {
        /// <summary>
        /// Calls a specific GET method on whatever interface this class represents. For example "IsPlayingSharedGame" is a method on the "PlayerService" web interface.
        /// </summary>
        /// <typeparam name="T">The type to parse the JSON response into and return</typeparam>
        /// <param name="methodName">The method name to call</param>
        /// <param name="version">The version of the method to call</param>
        /// <param name="parameters">An optional list of parameters to include with the call</param>
        /// <returns></returns>
        Task<ISteamWebResponse<T>> GetAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null);

        /// <summary>
        /// Calls a specific POST method on whatever interface this class represents. For example "IsPlayingSharedGame" is a method on the "PlayerService" web interface.
        /// </summary>
        /// <typeparam name="T">The type to parse the JSON response into and return</typeparam>
        /// <param name="methodName">The method name to call</param>
        /// <param name="version">The version of the method to call</param>
        /// <param name="parameters">An optional list of parameters to include with the call</param>
        /// <returns></returns>
        Task<ISteamWebResponse<T>> PostAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null);
    }
}