using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamWebInterface
    {
        private readonly SteamWebRequest steamWebRequest;
        private readonly string interfaceName;

        public SteamWebInterface(string steamWebApiKey, string interfaceName)
        {
            Debug.Assert(!String.IsNullOrEmpty(interfaceName));

            this.interfaceName = interfaceName;
            this.steamWebRequest = new SteamWebRequest(steamWebApiKey);
        }

        internal async Task<T> CallMethodAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(version > 0);

            return await steamWebRequest.GetJsonAsync<T>(interfaceName, methodName, version, parameters);
        }
    }
}
