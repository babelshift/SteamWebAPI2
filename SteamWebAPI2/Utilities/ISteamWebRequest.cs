using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebRequest
    {
        Task<T> GetAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null);

        Task<T> PostAsync<T>(string interfaceName, string methodName, int methodVersion, IList<SteamWebRequestParameter> parameters = null);
    }
}