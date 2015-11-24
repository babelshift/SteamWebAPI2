using SteamWebAPI2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamApps : SteamWebInterface
    {
        public SteamApps(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamApps")
        {
        }

        public async Task<IReadOnlyCollection<SteamApp>> GetAppListAsync()
        {
            var steamAppList = await CallMethodAsync<SteamAppListResultContainer>("GetAppList", 2);
            return new ReadOnlyCollection<SteamApp>(steamAppList.Result.Apps);
        }

        public async Task<SteamAppUpToDateCheckResult> UpToDateCheckAsync(int appId, int version)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("version", version, parameters);

            var upToDateCheckResult = await CallMethodAsync<SteamAppUpToDateCheckResultContainer>("UpToDateCheck", 1, parameters);
            return upToDateCheckResult.Result;
        }
    }
}