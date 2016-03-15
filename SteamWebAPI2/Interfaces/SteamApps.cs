using Steam.Models;
using SteamWebAPI2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class SteamApps : SteamWebInterface, ISteamApps
    {
        public SteamApps(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamApps")
        {
        }

        public async Task<IReadOnlyCollection<SteamAppModel>> GetAppListAsync()
        {
            var steamAppList = await CallMethodAsync<SteamAppListResultContainer>("GetAppList", 2);
            var steamAppModels = AutoMapperConfiguration.Mapper.Map<IList<SteamApp>, IList<SteamAppModel>>(steamAppList.Result.Apps);
            return new ReadOnlyCollection<SteamAppModel>(steamAppModels);
        }

        public async Task<SteamAppUpToDateCheckModel> UpToDateCheckAsync(int appId, int version)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(version, "version");

            var upToDateCheckResult = await CallMethodAsync<SteamAppUpToDateCheckResultContainer>("UpToDateCheck", 1, parameters);
            var upToDateCheckModel = AutoMapperConfiguration.Mapper.Map<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>(upToDateCheckResult.Result);
            return upToDateCheckModel;
        }
    }
}