using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public abstract class SteamStoreInterface
    {
        private const string steamStoreApiBaseUrl = "http://store.steampowered.com/api/";
        private readonly SteamStoreRequest steamStoreRequest;
        private readonly string endpointName;

        public SteamStoreInterface()
        {
            this.steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl);

            AutoMapperConfiguration.Initialize();
        }

        public SteamStoreInterface(string steamStoreApiBaseUrl)
        {
            this.steamStoreRequest = new SteamStoreRequest(steamStoreApiBaseUrl);

            AutoMapperConfiguration.Initialize();
        }

        internal async Task<T> CallMethodAsync<T>(string endpointName, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(endpointName));

            return await steamStoreRequest.SendStoreRequestAsync<T>(endpointName, parameters);
        }
    }
}
