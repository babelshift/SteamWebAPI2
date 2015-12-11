using SteamWebAPI2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamWebAPIUtil : SteamWebInterface, ISteamWebAPIUtil
    {
        public SteamWebAPIUtil(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamWebAPIUtil")
        { }

        public async Task<SteamServerInfo> GetServerInfoAsync()
        {
            var steamServerInfo = await CallMethodAsync<SteamServerInfo>("GetServerInfo", 1);
            return steamServerInfo;
        }

        public async Task<IReadOnlyCollection<SteamInterface>> GetSupportedAPIListAsync()
        {
            var steamApiListContainer = await CallMethodAsync<SteamApiListContainer>("GetSupportedAPIList", 1);
            return new ReadOnlyCollection<SteamInterface>(steamApiListContainer.Result.Interfaces);
        }
    }
}