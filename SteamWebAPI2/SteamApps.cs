using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamApps : SteamWebInterface
    {
        public SteamApps(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamApps")
        {
        }

        public async Task<IReadOnlyCollection<SteamApp>> GetAppList()
        {
            var steamAppList = await CallMethodAsync<SteamAppListResultContainer>("GetAppList", 1);
            return new ReadOnlyCollection<SteamApp>(steamAppList.AppListResult.AppList.Apps);
        }
    }
}
