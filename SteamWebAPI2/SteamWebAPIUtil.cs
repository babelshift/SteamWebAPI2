using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamWebAPIUtil : SteamWebInterface
    {
        public SteamWebAPIUtil(string steamWebApiKey) 
            : base(steamWebApiKey, "ISteamWebAPIUtil") { }

        public async Task<SteamServerInfo> GetServerInfoAsync()
        {
            var steamServerInfo = await CallMethodAsync<SteamServerInfo>("GetServerInfo", 1);
            return steamServerInfo;
        }

        public async Task<IReadOnlyCollection<SteamInterface>> GetSupportedAPIListAsync()
        {
            var steamApiListContainer = await CallMethodAsync<SteamApiListContainer>("GetSupportedAPIList", 1);
            return new ReadOnlyCollection<SteamInterface>(steamApiListContainer.ApiList.Interfaces);
        }
    }
}
