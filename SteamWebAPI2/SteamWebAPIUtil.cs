using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    internal class SteamWebAPIUtil : SteamWebRequest
    {
        public SteamWebAPIUtil(SteamWebRequestParameter developerKey) 
            : base(developerKey, "ISteamWebAPIUtil") { }

        public async Task<SteamServerInfo> GetServerInfoAsync()
        {
            var steamServerInfo = await GetJsonAsync<SteamServerInfo>(interfaceName, "GetServerInfo", 1);
            return steamServerInfo;
        }

        public async Task<IReadOnlyCollection<SteamInterface>> GetSupportedAPIListAsync()
        {
            var steamApiListContainer = await GetJsonAsync<SteamApiListContainer>(interfaceName, "GetSupportedAPIList", 1);
            return new ReadOnlyCollection<SteamInterface>(steamApiListContainer.ApiList.Interfaces);
        }
    }
}
