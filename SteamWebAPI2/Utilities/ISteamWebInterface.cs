using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebInterface
    {
        Task<T> GetAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null);

        Task<T> PostAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null);
    }
}